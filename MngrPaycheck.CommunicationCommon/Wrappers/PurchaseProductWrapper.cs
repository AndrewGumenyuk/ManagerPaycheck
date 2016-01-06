using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.CommunicationCommon.Wrappers
{
    public class PurchaseProductWrapper
    {
        public ObservableCollection<PurchaseProduct> CollectionBuyers { get; set; }
        public PurchaseProductWrapper()
        {
            this.CollectionBuyers = new ObservableCollection<PurchaseProduct>();
        }
    }
}
