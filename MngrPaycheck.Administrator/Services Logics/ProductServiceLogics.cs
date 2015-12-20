using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Administrator.ProductServiceRef;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.Administrator.Services_Logics
{
    public class ProductServiceLogics: Service
    {
        private ProductRepositoryServiceClient _service1Client;
        private WrapperProduct obj;

        public ProductServiceLogics(ServiceMediator mediator)
            : base(mediator)
        {
            this._service1Client = new ProductRepositoryServiceClient();
            obj = JsonConvert.DeserializeObject<WrapperProduct>(_service1Client.GetProducts());
        }

        public ObservableCollection<Product> Products()
        {
            return obj.CollectionProducts;
        }

        public override void Add(string json)
        {
            _service1Client.AddProduct(json);
        }

        public override void Delete(string json)
        {
            _service1Client.DeleteProduct(json);
        }

        public override void Update(string json)
        {
            _service1Client.UpdateProducts(json);
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
