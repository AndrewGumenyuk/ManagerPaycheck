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
    public class ProductTypeServiceLogics
    {
        private ProductTypeRepositoryServiceClient _serviceProductTypeClient;
        private WrapperProductType obj;

        public ProductTypeServiceLogics()
        {
            this._serviceProductTypeClient = new ProductTypeRepositoryServiceClient();
            obj = JsonConvert.DeserializeObject<WrapperProductType>(_serviceProductTypeClient.GetProductTypes());
        }
        
        public ObservableCollection<ProductType> ProductTypes()
        {
            return obj.CollectionProductTypes;
        }

        public void AddProductType(string json)
        {
            _serviceProductTypeClient.AddProductType(json);
        }

        public void DeleteProduct(string json)
        {
            _serviceProductTypeClient.DeleteProductType(json);
        }

        public void UpdateProductTypes(string json)
        {
            _serviceProductTypeClient.UpdateProductTypes(json);
        }

        public string SerializeProduct(object entity)
        {
            var settings = new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
            return JsonConvert.SerializeObject(entity, settings);
        }
    }
}
