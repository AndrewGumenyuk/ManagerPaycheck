using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;

namespace ProductService
{
    public class WrapperProduct
    {
        public List<Product> CollectionProducts { get; set; }

        private ProductRepository _productRepository;

        public WrapperProduct()
        {
            _productRepository = new ProductRepository(MngPaycheckContext.Instance);
            CollectionProducts = (List<Product>) _productRepository.GetAll();
        }
    }
}
