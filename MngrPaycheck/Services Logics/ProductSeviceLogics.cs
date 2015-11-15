using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;
using MngrPaycheck.ProductServiceReference;
using Newtonsoft.Json;
using ProductService;

namespace MngrPaycheck.Services_Logics
{
    public class ProductSeviceLogics
    {
        ProductServiceReference.Service1Client _service1Client = new Service1Client();

        private WrapperProduct obj;

        public ProductSeviceLogics()
        {
            obj = JsonConvert.DeserializeObject<WrapperProduct>(_service1Client.GetProducts());
        }

        public List<Product> Products()
        {
            return obj.CollectionProducts;
        }
    }
}
