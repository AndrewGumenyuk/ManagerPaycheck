using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.ProductParameterServiceRefer;
using MngrPaycheck.CommunicationCommon.Wrappers;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.CommunicationCommon.Concrete.Proxies
{
    public class ProductParameterServiceProxy : 
        ClientBase<IProductParameterRepositoryService>,
        IProductParameterRepositoryService,
        IGeneralService<ProductParametr>
    {
        private ProductParameterWrapper obj;

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

        public ObservableCollection<ProductParametr> Deserialize(string json)
        {
            obj = new ProductParameterWrapper();
            obj = JsonConvert.DeserializeObject<ProductParameterWrapper>(base.Channel.GetAll());
            return obj.CollectionProductParametrs;
        }
    }
}
