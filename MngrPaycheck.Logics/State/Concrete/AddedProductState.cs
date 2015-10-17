using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics.State.Infrastructure;

namespace MngrPaycheck.Logics.State.Concrete
{
    public class AddedProductState : IState
    {
        private LogicsState _logicsState;
        public AddedProductState(LogicsState logicsState)
        {
            this._logicsState = logicsState;
        }

        public void AddProduct(Product product)
        {
            Console.WriteLine("+ Added a product. Let`s add the product type");
            _logicsState.SetState(_logicsState.AddedProductTypeState);
        }

        public void AddProductType(ProductType productType)
        {
            Console.WriteLine("Sorry man ! But the first add product");
        }

        public void AddProductParametr(List<ProductParametr> productParametrs)
        {
            Console.WriteLine("Impossible ! The first add product");
        }

        public void AddProductParametrValue(ProductParametr productParametr, ProductParametrValue productParametrValue)
        {
            Console.WriteLine("I'm sorry bro ! The first add product");
        }
    }
}
