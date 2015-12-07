using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Administrator.ProductServiceRef;
using MngrPaycheck.Administrator.ProductTypeServiceRef;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.Administrator.Services_Logics
{
    public class ProductTypeServiceLogics: Service
    {
        private ProductTypeRepositoryServiceClient _serviceProductTypeClient;
        private WrapperProductType obj;

        public ProductTypeServiceLogics(ServiceMediator mediator) : base(mediator)
        {
            this._serviceProductTypeClient = new ProductTypeRepositoryServiceClient();
            obj = JsonConvert.DeserializeObject<WrapperProductType>(_serviceProductTypeClient.GetProductTypes());

        }

        public ObservableCollection<ProductType> Products()
        {
            return obj.CollectionProductTypes;
        }

        public override void Add(string json)
        {
            _serviceProductTypeClient.AddProductType(json);
        }

        public override void Delete(string json)
        {
            _serviceProductTypeClient.DeleteProductType(json);
        }

        public override void Update(string json)
        {
            _serviceProductTypeClient.UpdateProductTypes(json);
        }

        public override string Serialize(object entity)
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            return JsonConvert.SerializeObject(entity, settings);
        }
    }
}
