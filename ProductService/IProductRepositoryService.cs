using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MngrPaycheck.Entity;
using ProductService.Abstract1;

namespace ProductService
{
    [ServiceContract(CallbackContract = typeof(IProductRepositoryServiceCallback))]
    public interface IProductRepositoryService
    {
        [OperationContract]
        string GetAll();

        [OperationContract]
        void Add(string json);

        [OperationContract]
        void Delete(string json);

        [OperationContract]
        void Update(string json);

        #region Operation for working with callbacks
        /// <summary>
        /// Subcribes a client for any message broadcast.
        /// </summary>
        /// <returns>An id that will identify a client.</returns>
        [OperationContract]
        Guid Subscribe();

        /// <summary>
        /// Unsubscribes a client from any message broadcast.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        [OperationContract(IsOneWay = true)]
        void Unsubscribe(Guid clientId);

        /// <summary>
        /// Keeps the connection between the client and server.
        /// Connection between a client and server has a time-out,
        /// so the client needs to call this before that happens
        /// to remain connected to the server.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void KeepConnection();

        /// <summary>
        /// Broadcasts a message to other connected clients.
        /// </summary>
        /// <param name="clientId">The client id.</param>
        /// <param name="message">The message to be broadcasted.</param>
        [OperationContract]
        void SendMessage(Guid clientId, string message);
        #endregion
    }
}
