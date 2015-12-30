using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.ProductTypeServiceRef;
using MngrPaycheck.CommunicationCommon.Wrappers;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.CommunicationCommon.Concrete.Proxies
{
    public class ProductTypeServiceProxy : 
        ClientBase<IProductTypeRepositoryService>,
        IProductTypeRepositoryService,
        IGeneralService<ProductType>
    {
        private ProductTypeWrapper obj;

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

        public ObservableCollection<ProductType> Deserialize(string json)
        {
            this.obj = new ProductTypeWrapper();
            this.obj = JsonConvert.DeserializeObject<ProductTypeWrapper>(base.Channel.GetAll());
            return this.obj.CollectionProductTypes;
        }
    }
}
