using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.ProductServiceRef;
using MngrPaycheck.CommunicationCommon.Wrappers;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.CommunicationCommon.Concrete.Proxies
{
    public class ProductServiceProxy : 
        ClientBase<IProductRepositoryService>,
        IProductRepositoryService,
        IGeneralService<Product>
    {

        private ProductRepositoryServiceClient chatServiceClient;
        private InstanceContext instanceContext;

        private IProductRepositoryService instance;

        public ProductServiceProxy()
        {
            ChatServiceCallback chatServiceCallback = new ChatServiceCallback();
            instanceContext = new InstanceContext(chatServiceCallback);
            chatServiceClient = new ProductRepositoryServiceClient(instanceContext);
        }

        public void Add(string json)
        {
            chatServiceClient.Add(json);
        }

        public void Delete(string json)
        {
            chatServiceClient.Delete(json);
        }

        public void Update(string json)
        {
            chatServiceClient.Update(json);
        }
        
        public string GetAll()
        {
            return chatServiceClient.GetAll();
        }

        public string Serialize(object entity)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Product> Deserialize(string json)
        {
             return JsonConvert.DeserializeObject<ProductWrapper>
                 (chatServiceClient.GetAll()).CollectionProducts;
        }

        public Guid Subscribe()
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public void KeepConnection()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(Guid clientId, string message)
        {
            throw new NotImplementedException();
        }
    }

   

    public class ChatServiceCallback : IProductRepositoryServiceCallback
    {
        public event ClientNotifiedEventHandler ClientNotified;

        /// <summary>
        /// Notifies the client of the message by raising an event.
        /// </summary>
        /// <param name="message">Message from the server.</param>
        void IProductRepositoryServiceCallback.HandleMessage(string message)
        {
            if (ClientNotified != null)
            {
                ClientNotified(this, new ClientNotifiedEventArgs(message));
            }
        }
    }


    public delegate void ClientNotifiedEventHandler(object sender, ClientNotifiedEventArgs e);

    /// <summary>
    /// Custom event arguments.
    /// </summary>
    public class ClientNotifiedEventArgs : EventArgs
    {
        private readonly string message;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Message from server.</param>
        public ClientNotifiedEventArgs(string message)
        {
            this.message = message;
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get { return message; } }
    }
}
