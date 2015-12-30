using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.ProductServiceRef;
using MngrPaycheck.CommunicationCommon.Wrappers;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.CommunicationCommon.Concrete.Proxies
{
    public class ProductServiceProxy : 
        ClientBase<IProductRepositoryService>,
        IProductRepositoryService,
        IGeneralService<Product>
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

        private ProductWrapper obj;

        public ObservableCollection<Product> Deserialize(string json)
        {
             return JsonConvert.DeserializeObject<ProductWrapper>
                 (base.Channel.GetAll()).CollectionProducts;
        }
    }
}
