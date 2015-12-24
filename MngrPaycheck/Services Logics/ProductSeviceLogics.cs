using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;
using MngrPaycheck.ProductServiceReference;
using Newtonsoft.Json;

namespace MngrPaycheck.Services_Logics
{
    public class ProductSeviceLogics
    {
        ProductRepositoryServiceClient _service1Client = new ProductRepositoryServiceClient();

        private WrapperProductUser obj;

        public ProductSeviceLogics()
        {
            obj = JsonConvert.DeserializeObject<WrapperProductUser>(_service1Client.GetProducts());
        }

        public ObservableCollection<Product> Products()
        {
            return obj.CollectionProducts;
        }
    }
}
