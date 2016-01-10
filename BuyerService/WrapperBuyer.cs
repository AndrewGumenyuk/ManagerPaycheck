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

namespace BuyerService
{
    public class WrapperBuyer
    {
        public List<Buyer> CollectionBuyers { get; set; }

        public WrapperBuyer()
        {
            IoCManagerCore.Start();
            this.CollectionBuyers = (List<Buyer>) IoCManagerCore.Kernel.Get<IBuyerRepository>().GetAll();
        }

        public Buyer Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Buyer>(json);
        }
    }
}
