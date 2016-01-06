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

namespace PurchaseProductService
{
    class WrapperPurchaseProduct
    {
        public List<PurchaseProduct> CollectionPurchaseProducts { get; set; }

        public WrapperPurchaseProduct()
        {
            IoCManagerCore.Start();
            CollectionPurchaseProducts = (List<PurchaseProduct>)IoCManagerCore.Kernel.Get<IPurchaseProductRepository>().GetAll();
        }

        public List<PurchaseProduct> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<List<PurchaseProduct>>(json);
        }
    }
}
