using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics.State.Infrastructure;

namespace MngrPaycheck.Logics.State.Concrete
{
    public class AddedProductParametrValueState: IState
    {
        private readonly LogicsState _logicsState;

        public AddedProductParametrValueState(LogicsState logicsState)
        {
            this._logicsState = logicsState;
        }

        public void AddProduct(Product product)
        {
            Console.WriteLine("You have already added the product, type of product and parametres of product !" +
                              " Please, will add the parametr value of product");
        }

        public void AddProductType(ProductType productType)
        {
            Console.WriteLine("Man !!! You have already added the type of product and parametres of product !" +
                              "Please, will add the parametr value of product");
        }

        public void AddProductParametr(List<ProductParametr> productParametrs)
        {
            Console.WriteLine("Bro !!! You have already added the type of product and parametres of product !" +
                              "Please, will add the parametr value of product");
        }

        //сделать проверку, на то что если парам
        //TODO: Сделать проверку если есть пустые параметры, без значений, - нужно фиксить
        public void AddProductParametrValue(ProductParametr productParametr, ProductParametrValue productParametrValue)
        {
            Console.WriteLine("+ You added value to parametr");
        }
    }
}
