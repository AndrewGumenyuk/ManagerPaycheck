using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MngrPaycheck.Administrator.Services_Logics;
using MngrPaycheck.Administrator.Services_Logics.Wrapper;
using MngrPaycheck.Entity;
using MVVMCommon;
using Newtonsoft.Json;

namespace MngrPaycheck.Administrator.ViewModel.Product.VMProducts
{
    public class AddValueToParametrVM : ViewModelBase
    {
        private ProductServiceLogics _productServiceLogics;

        private ObservableCollection<Entity.Product> _products;

        private Service productParameterValueService;
        private Service prodService;

        public AddValueToParametrVM()
        {
            ManagerServiceMediator mediator = new ManagerServiceMediator();
            productParameterValueService = new ProductParametrValueServiceLogics(mediator);
            prodService = new ProductServiceLogics(mediator);

            mediator.ProductParametrValue = productParameterValueService;
            mediator.Product = prodService;

            _productServiceLogics = new ProductServiceLogics(mediator);
            Products = _productServiceLogics.Products();
        }

        ObservableCollection<Entity.Product> _Products;
        public ObservableCollection<Entity.Product> Products
        {
            get { return _Products; }
            set
            {
                _Products = value;
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
                    ProductParametrs = new ObservableCollection<ProductParametr>(value.ProductType.ProductParametrs);
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
                catch (Exception) { Console.WriteLine("Wow");}
                NotifyPropertyChanged("SelectedProductParameter");
            }
        }
       
        private void AddProductParameter()
        {            
            productParameterValueService.Add(productParameterValueService.Serialize(GetProductParametrValue()));
            InsteadProductParametrWithValue();
        }

        private void DeleteProductValue()
        {
            productParameterValueService.Delete(productParameterValueService.Serialize(GetProductParametrValue()));
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
            productParameterValueService.Update(productParameterValueService.Serialize(GetProductParametrValue()));
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
