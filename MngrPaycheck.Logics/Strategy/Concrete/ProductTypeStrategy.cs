using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics.Strategy.Abstract;

namespace MngrPaycheck.Logics.Strategy.Concrete
{
    public class ProductTypeStrategy : BaseStrategy<Product>
    {
        private readonly IProductRepository _productRepository = new ProductRepository(new MngPaycheckContext());
        public override IEnumerable<Product> GetElements(object TypeProduct)
        {
            return
                _productRepository.GetAll().Where(a => a.ProductType.Name == ((ProductType)TypeProduct).Name).ToList();
        }
    }
}
