using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;
using ProductService.Abstract1;

namespace ProductService
{
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ProductRepositoryService : IProductRepositoryService
    {
        private IProductRepository _productRepository;
        private readonly Dictionary<Guid, IProductRepositoryServiceCallback> clients;
        private WrapperProduct wrapperProduct;

        public ProductRepositoryService()
        {
            IoCManagerCore.Start();
            _productRepository = IoCManagerCore.Kernel.Get<IProductRepository>();
            clients = clients = new Dictionary<Guid, IProductRepositoryServiceCallback>();
            wrapperProduct = new WrapperProduct();
        }

        public string GetAll()
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            
            string json = JsonConvert.SerializeObject(wrapperProduct, settings);
            return json;
        }
        public void Add(string json)
        {
            _productRepository.Add(wrapperProduct.DeserializeProduct(json));
            _productRepository.Save();
        }
        public void Delete(string json)
        {
            _productRepository.Delete(_productRepository.GetById(wrapperProduct.DeserializeProduct(json).Id));
            _productRepository.Save();
        }
        public void Update(string json)
        {
            _productRepository.Delete(_productRepository.GetById(wrapperProduct.DeserializeProduct(json).Id));
            _productRepository.Add(wrapperProduct.DeserializeProduct(json));
            _productRepository.Save();
        }

        #region IChatService

        Guid IProductRepositoryService.Subscribe()
        {
            IProductRepositoryServiceCallback callback =
                OperationContext.Current.GetCallbackChannel<IProductRepositoryServiceCallback>();

            Guid clientId = Guid.NewGuid();

            if (callback != null)
            {
                lock (clients)
                {
                    clients.Add(clientId, callback);
                }
            }

            return clientId;
        }

        void IProductRepositoryService.Unsubscribe(Guid clientId)
        {
            lock (clients)
            {
                if (clients.ContainsKey(clientId))
                {
                    clients.Remove(clientId);
                }
            }
        }

        void IProductRepositoryService.KeepConnection()
        {
            // Do nothing.
        }

        void IProductRepositoryService.SendMessage(Guid clientId, string message)
        {
            BroadcastMessage(clientId, message);
        }
        #endregion

        /// <summary>
        /// Notifies the clients of messages.
        /// </summary>
        /// <param name="clientId">Identifies the client that sent the message.</param>
        /// <param name="message">The message to be sent to all connected clients.</param>
        private void BroadcastMessage(Guid clientId, string message)
        {
            // Call each client's callback method
            ThreadPool.QueueUserWorkItem
            (
                delegate
                {
                    lock (clients)
                    {
                        List<Guid> disconnectedClientGuids = new List<Guid>();

                        foreach (KeyValuePair<Guid, IProductRepositoryServiceCallback> client in clients)
                        {
                            try
                            {
                                client.Value.HandleMessage(message);
                            }
                            catch (Exception)
                            {
                                // TODO: Better to catch specific exception types.                     

                                // If a timeout exception occurred, it means that the server
                                // can't connect to the client. It might be because of a network
                                // error, or the client was closed  prematurely due to an exception or
                                // and was unable to unregister from the server. In any case, we 
                                // must remove the client from the list of clients.

                                // Another type of exception that might occur is that the communication
                                // object is aborted, or is closed.

                                // Mark the key for deletion. We will delete the client after the 
                                // for-loop because using foreach construct makes the clients collection
                                // non-modifiable while in the loop.
                                disconnectedClientGuids.Add(client.Key);
                            }
                        }

                        foreach (Guid clientGuid in disconnectedClientGuids)
                        {
                            clients.Remove(clientGuid);
                        }
                    }
                }
            );
        }
    }
}
