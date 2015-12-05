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
    public class ProductSeviceLogics
    {
        private ProductRepositoryServiceClient _service1Client;
        private WrapperProduct obj;

        public ProductSeviceLogics()
        {
            this._service1Client = new ProductRepositoryServiceClient();
            obj = JsonConvert.DeserializeObject<WrapperProduct>(_service1Client.GetProducts());
        }

        public ObservableCollection<Product> Products()
        {
            return obj.CollectionProducts;
        }

        public void AddProduct(string json)
        {
            _service1Client.AddProduct(json);
        }

        public void DeleteProduct(string json)
        {
            _service1Client.DeleteProduct(json);
        }

        public void UpdateProducts(string json)
        {
            _service1Client.UpdateProducts(json);
        }

        public string SerializeProduct(object product)
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            return JsonConvert.SerializeObject(product, settings);
        }
    }
}
