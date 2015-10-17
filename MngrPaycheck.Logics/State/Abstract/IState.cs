using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Logics.State.Infrastructure
{
    public interface IState
    {
        void AddProduct(Product product);
        void AddProductType(ProductType productType);
        void AddProductParametr(List<ProductParametr> productParametrs);
        void AddProductParametrValue(ProductParametr productParametr, ProductParametrValue productParametrValue);
    }
}
