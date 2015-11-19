using System;
using System.Collections.Generic;
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
        ProductRepositoryServiceClient _service1Client = new ProductRepositoryServiceClient();

        private WrapperProductAdministrator obj;

        public ProductSeviceLogics()
        {
            obj = JsonConvert.DeserializeObject<WrapperProductAdministrator>(_service1Client.GetProducts());
        }

        public List<Product> Products()
        {
            return obj.CollectionProducts;
        }
    }
}
