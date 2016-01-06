using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.Entity;
using MngrPaycheck.IoCManager;
using Newtonsoft.Json;
using Ninject;

namespace PurchaseService
{
    public class WrapperPurchase
    {
        public List<Purchase> CollectionPurchases { get; set; }
        public WrapperPurchase()
        {
            IoCManagerCore.Start();
            CollectionPurchases = (List<Purchase>) IoCManagerCore.Kernel.Get<IPurchaseRepository>().GetAll();
        }

        public Purchase DeserializePurchase(string json)
        {
            return JsonConvert.DeserializeObject<Purchase>(json);
        }
    }
}
