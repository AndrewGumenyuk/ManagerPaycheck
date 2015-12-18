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
                OnPropertyChanged("Products");
            }
        }

        public Entity.Product _selectedProduct;
        public Entity.Product SelectedProduct // It Is selected product in listview
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                if (value.ProductParametrValues != null)
                {
                    ProductParametrValues = new ObservableCollection<ProductParametrValue>(value.ProductParametrValues);
                }
            }
        }

        public ObservableCollection<ProductParametrValue> _ProductParametrValues;
        public ObservableCollection<ProductParametrValue> ProductParametrValues
        {
            get { return _ProductParametrValues; }
            set
            {
                _ProductParametrValues = value;
                NotifyPropertyChanged("ProductParametrValues");
            }
        }

        public ProductParametrValue _selectedProductParameterValue;
        public ProductParametrValue SelectedProductParameterValue
        {
            get { return _selectedProductParameterValue; }
            set
            {
                _selectedProductParameterValue = value;
                try
                {
                    _selectedProductParameterValue = new ProductParametrValue();
                    _selectedProductParameterValue.Product = value.Product;
                    _selectedProductParameterValue.ProductID = value.ProductID;
                    _selectedProductParameterValue.ProductParameterID = value.ProductParameterID;
                    _selectedProductParameterValue.ProductParametr = value.ProductParametr;
                    _selectedProductParameterValue.Value = value.Value;
                }
                catch (Exception) { }
                NotifyPropertyChanged("SelectedProductParameterValue");
            }
        }
        
        private void AddProductParameter()
        {
            ProductParametrValues.Add(SelectedProductParameterValue);
            foreach (var item in Products)
            {
                if (item.Id == SelectedProductParameterValue.ProductID )
                {
                    SelectedProductParameterValue.Product = null;
                    item.ProductParametrValues.Add(SelectedProductParameterValue);                   
                }
            }

            

            MessageBox.Show("Parameter was added to product of type", "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public ICommand AddProductParameterCommand
        {
            get { return new RelayCommand(c => AddProductParameter()); }
        }

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
