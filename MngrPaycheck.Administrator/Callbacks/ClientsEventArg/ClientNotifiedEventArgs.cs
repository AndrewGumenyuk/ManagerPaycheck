using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Administrator.Callbacks.ClientsEventArg
{
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
