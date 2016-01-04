using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Serialization;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace ProductService
{
    public class WrapperProduct
    {
        public List<Product> CollectionProducts { get; set; }

        private IProductRepository _productRepository = new ProductRepository(new MngPaycheckContext());

        public WrapperProduct()
        {
            //_productRepository = DependencyResolver.Current.GetService<IProductRepository>();
            CollectionProducts = (List<Product>) _productRepository.GetAll();
        }

        public Product DeserializeProduct(string json)
        {
            return JsonConvert.DeserializeObject<Product>(json);
        }
    }
}
