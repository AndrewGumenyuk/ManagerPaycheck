using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.PurchaseProductServiceRef;
using MngrPaycheck.CommunicationCommon.Wrappers;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.CommunicationCommon.Concrete.Proxies
{
    public class PurchaseProductServiceProxy : ClientBase<IPurchaseProductRepositoryService>,
        IPurchaseProductRepositoryService, IGeneralService<PurchaseProduct>
    {
        public void Add(string json)
        {
           base.Channel.Add(json);
        }

        public void Delete(string json)
        {
            base.Channel.Delete(json);
        }

        public void Update(string json)
        {
            base.Channel.Update(json);
        }
        public string GetAll()
        {
            return base.Channel.GetAll();
        }

        public string Serialize(object entity)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<PurchaseProduct> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<PurchaseProductWrapper>
                (base.Channel.GetAll()).CollectionBuyers;
        }
    }
}
