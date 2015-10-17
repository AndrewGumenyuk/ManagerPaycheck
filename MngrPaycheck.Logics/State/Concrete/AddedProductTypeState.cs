using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics.State.Infrastructure;

namespace MngrPaycheck.Logics.State.Concrete
{
    public class AddedProductTypeState: IState
    {
        private readonly LogicsState _logicsState;

        public AddedProductTypeState(LogicsState logicsState)
        {
            this._logicsState = logicsState;
        }

        public void AddProduct(Product product)
        {
            Console.WriteLine("You added the product ! Please, add type of product");
        }

        public void AddProductType(ProductType productType)
        {
            Console.WriteLine("+ You added the type ! After that add parametr of product");
            _logicsState.SetState(_logicsState.AddedProductParametrState);
        }

        public void AddProductParametr(List<ProductParametr> productParametrs)
        {
            Console.WriteLine("Please, add the type of product, after that add the parametr of product");
        }

        public void AddProductParametrValue(ProductParametr productParametr, ProductParametrValue productParametrValue)
        {
            Console.WriteLine("Bro, add the type of product, after that add the parametr of product");
        }
    }
}
