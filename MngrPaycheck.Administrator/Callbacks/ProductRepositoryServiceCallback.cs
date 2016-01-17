using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Administrator.Callbacks.ClientsEventArg;
using MngrPaycheck.Administrator.ProductServiceRef;
using MngrPaycheck.Administrator.ViewModel;

namespace MngrPaycheck.Administrator.Callbacks
{
    public class ProductRepositoryServiceCallback : IProductRepositoryServiceCallback
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
}
