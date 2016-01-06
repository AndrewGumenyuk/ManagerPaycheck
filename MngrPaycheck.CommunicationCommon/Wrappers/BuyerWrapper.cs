using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.CommunicationCommon.Wrappers
{
    public class BuyerWrapper
    {
        public ObservableCollection<Buyer> CollectionBuyers { get; set; }
        public BuyerWrapper()
        {
            this.CollectionBuyers = new ObservableCollection<Buyer>();
        }
    }
}
