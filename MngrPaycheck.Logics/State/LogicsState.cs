using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics.State.Concrete;
using MngrPaycheck.Logics.State.Infrastructure;

namespace MngrPaycheck.Logics.State
{
    public class LogicsState
    {

        private IState _state;

        public AddedProductState AddedProductState { get; private set; }
        public AddedProductTypeState AddedProductTypeState { get; set; }
        public AddedProductParametrState AddedProductParametrState { get; set; }
        public AddedProductParametrValueState AddedProductParametrValueState { get; set; }

        public LogicsState()
        {
            this.AddedProductState = new AddedProductState(this);
            this.AddedProductTypeState = new AddedProductTypeState(this);
            this.AddedProductParametrState = new AddedProductParametrState(this);
            this.AddedProductParametrValueState = new AddedProductParametrValueState(this);
        }

        public void SetState(IState state)
        {
            this._state = state;
        }

        public void AddProduct(Product product)
        {
            _state.AddProduct(product);
        }

        public void AddProductType(ProductType productType)
        {
            _state.AddProductType(productType);
        }

        public void AddProductParametr(List<ProductParametr> productParametrs)
        {
            _state.AddProductParametr(productParametrs);
        }

        public void AddProductParametrValue(ProductParametr productParametr, ProductParametrValue productParametrValue)
        {
            _state.AddProductParametrValue(productParametr, productParametrValue);
        }
    }
}
