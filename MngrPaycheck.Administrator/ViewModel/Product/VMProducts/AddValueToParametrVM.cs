using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.Concrete;
using MngrPaycheck.CommunicationCommon.Concrete.Proxies;
using MngrPaycheck.Entity;
using MVVMCommon;

namespace MngrPaycheck.Administrator.ViewModel.Product.VMProducts
{
    public class AddValueToParametrVM : ViewModelBase
    {
        private IGeneralService<Entity.Product> surrogateProduct;
        private IGeneralService<Entity.ProductParametrValue> surrogateProductParametrValue;

        public AddValueToParametrVM()
        {
            surrogateProduct = new Surrogate<Entity.Product>(new ProductServiceProxy());
            surrogateProductParametrValue = new Surrogate<Entity.ProductParametrValue>(new ProductParameterValueServiceProxy());
            Products = surrogateProduct.Deserialize(surrogateProduct.GetAll());
        }

       
        ObservableCollection<Entity.Product> _products;
        public ObservableCollection<Entity.Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyPropertyChanged("Products");
            }
        }

        public Entity.Product _selectedProduct;
        public Entity.Product SelectedProduct // It Is selected product in listview
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                if (value.ProductType.ProductParametrs != null)
                {
                    //ProductParametrs = new ObservableCollection<ProductParametr>(value.ProductType.ProductParametrs);
                    ProductParametrs = new ObservableCollection<ProductParametr>();
                    if (value.ProductParametrValues.Count != 0)
                    {
                        foreach (var item in value.ProductParametrValues)
                        {
                            item.ProductParametr.ProductParametrValue = item;
                            ProductParametrs.Add(item.ProductParametr);
                        }
                    }
                    else
                    {
                        foreach (var item in value.ProductType.ProductParametrs)
                        {
                            item.ProductParametrValue = null;
                            ProductParametrs.Add(item);
                        }
                    }
                }
            }
        }



        public ObservableCollection<ProductParametr> _productParametrs;
        public ObservableCollection<ProductParametr> ProductParametrs
        {
            get { return _productParametrs; }
            set
            {
                _productParametrs = value;
                NotifyPropertyChanged("ProductParametrs");
            }
        }

        public ProductParametr _selectedProductParameter;
        public ProductParametr SelectedProductParameter
        {
            get { return _selectedProductParameter; }
            set
            {
                _selectedProductParameter = value;

                try
                {
                    _selectedProductParameter = new ProductParametr();
                    _selectedProductParameter.Id = value.Id;
                    _selectedProductParameter.Name = value.Name;
                    _selectedProductParameter.ProductType = value.ProductType;
                    _selectedProductParameter.ProductParametrValue = new ProductParametrValue();

                    if (_selectedProductParameter.ProductParametrValue == null)
                    {
                        _selectedProductParameter.ProductParametrValue = new ProductParametrValue();
                    }
                    _selectedProductParameter.ProductParametrValue.Value = value.ProductParametrValue.Value;
                }
                catch (Exception) { Console.WriteLine("Wow"); }
                NotifyPropertyChanged("SelectedProductParameter");
            }
        }

        private void AddProductParameter()
        {
            surrogateProductParametrValue.Add(surrogateProductParametrValue.Serialize(GetProductParametrValue()));
            InsteadProductParametrWithValue();
        }

        private void DeleteProductValue()
        {
            surrogateProductParametrValue.Delete(surrogateProductParametrValue.Serialize(GetProductParametrValue()));
            ProductParametr pr = SelectedProductParameter;
            pr.ProductParametrValue = null;
            SelectedProductParameter.ProductType.ProductParametrs.Where(param => param.Id == SelectedProductParameter.Id)
                        .Single()
                        .ProductParametrValue = null;
            ProductParametrs.Remove(
                ProductParametrs.Where(prm => prm.Id == SelectedProductParameter.Id).ToList().FirstOrDefault());
            ProductParametrs.Add(pr);
        }

        #region helper methods
        private void UpdateProductParameter()
        {
            surrogateProductParametrValue.Update(surrogateProductParametrValue.Serialize(GetProductParametrValue()));
            InsteadProductParametrWithValue();
        }

        public ProductParametrValue GetProductParametrValue()
        {
            ProductParametrValue pr = SelectedProductParameter.ProductParametrValue;
            pr.Value = SelectedProductParameter.ProductParametrValue.Value;
            pr.ProductParametr = SelectedProductParameter;
            pr.ProductParameterID = SelectedProductParameter.Id;
            pr.ProductID = SelectedProduct.Id;
            pr.Product = SelectedProduct;
            return pr;
        }

        public void InsteadProductParametrWithValue()
        {
            ProductParametr prParam = SelectedProductParameter;
            prParam.ProductParametrValue = GetProductParametrValue();

            SelectedProductParameter.ProductType.ProductParametrs
                .Where(par => par.Id == GetProductParametrValue().ProductParameterID)
                .Single()
                .ProductParametrValue = GetProductParametrValue();

            ProductParametrs.Remove(ProductParametrs.Where(prm => prm.Id == SelectedProductParameter.Id)
                .ToList()
                .FirstOrDefault());

            ProductParametrs.Add(prParam);
        }

        #endregion
        #region Commands
        public ICommand AddProductValueCommand
        {
            get { return new RelayCommand(c => AddProductParameter()); }
        }
        public ICommand DeleteProductValueCommand
        {
            get { return new RelayCommand(c => DeleteProductValue()); }
        }

        public ICommand UpdateProductValueCommand
        {
            get { return new RelayCommand(c => UpdateProductParameter()); }
        }
        #endregion
        #region Events
        public event PropertyChangedEventHandler ProductPropertyChanged;
        #endregion
        #region Private Methods
        private void OnPropertyChanged(string propertyChanged)
        {
            if (ProductPropertyChanged != null)
                ProductPropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
        #endregion
    }
}
