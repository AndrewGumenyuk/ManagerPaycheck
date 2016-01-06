using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.CommunicationCommon.Wrappers
{
    public class PurchaseWrapper
    {
        public ObservableCollection<Purchase> CollectionPurchases { get; set; }
        public PurchaseWrapper()
        {
            this.CollectionPurchases = new ObservableCollection<Purchase>();
        }
    }
}
