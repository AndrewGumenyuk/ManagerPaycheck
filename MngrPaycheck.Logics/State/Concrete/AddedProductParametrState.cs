using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics.State.Infrastructure;

namespace MngrPaycheck.Logics.State.Concrete
{
    public class AddedProductParametrState: IState
    {
        private readonly LogicsState _logicsState;
        public AddedProductParametrState(LogicsState logicsState)
        {
            this._logicsState = logicsState;
        }

        public void AddProduct(Product product)
        {
            Console.WriteLine("You added the product please, add the parametr of product");
        }

        public void AddProductType(ProductType productType)
        {
            Console.WriteLine("You added the type of product ! Please, add the parametr of product");
        }

        public void AddProductParametr(List<ProductParametr> productParametrs)
        {
            Console.WriteLine("+ You added the parametrs of product");
            _logicsState.SetState(_logicsState.AddedProductParametrValueState);
        }

        public void AddProductParametrValue(ProductParametr productParametr, ProductParametrValue productParametrValue)
        {
            Console.WriteLine("You added value of product parametr, please add the parametr of product");
        }
    }
}
