using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Abstract1
{
    /// <summary>
    /// The callback contract to be implemented by the client
    /// application.
    /// </summary>
    public interface IProductRepositoryServiceCallback
    {
        /// <summary>
        /// Implemented by the client so that the server may call
        /// this when it receives a message to be broadcasted.
        /// </summary>
        /// <param name="message">
        /// The message to broadcast.
        /// </param>
        [OperationContract(IsOneWay = true)]
        void HandleMessage(string message);
    }
}
