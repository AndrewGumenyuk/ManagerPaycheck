using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MngrPaycheck.Administrator.Services_Logics;
using MngrPaycheck.Entity;
using MVVMCommon;

namespace MngrPaycheck.Administrator.ViewModel.Product.VMProducts
{
    public class AddProductParametrVM : ViewModelBase
    {
        private ProductServiceLogics _productSeviceLogics;
        private ObservableCollection<Entity.Product> _products;
        private Service productParameterService;

        public AddProductParametrVM()
        {
            SelectedProduct = new Entity.Product();
            SelectedProduct.ProductType = new ProductType();
            SelectedProductParameter = new ProductParametr();

            ManagerServiceMediator mediator = new ManagerServiceMediator();
            productParameterService = new ProductParametrServiceLogics(mediator);
            mediator.ProductParametr = productParameterService;

            _productSeviceLogics = new ProductServiceLogics(mediator);
            Products = _productSeviceLogics.Products();    
            ProductParametrs = new ObservableCollection<ProductParametr>(Products.Select(a => a.ProductType).ToList().FirstOrDefault().ProductParametrs.ToList());
        }

        ObservableCollection<Entity.Product> _Products;
        public ObservableCollection<Entity.Product> Products
        {
            get { return _Products; }
            set { _Products = value;
                OnPropertyChanged("Products"); }}

        public Entity.Product _selectedProduct;
        public Entity.Product SelectedProduct // It Is selected product in listview
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                if (value.ProductType != null)
                {
                    ProductParametrs = new ObservableCollection<ProductParametr>(value.ProductType.ProductParametrs);
                }
                NotifyPropertyChanged("SelectedProduct");
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
                    _selectedProductParameter.ProductType = SelectedProduct.ProductType;
                    //_selectedProductParameter.ProductTypeID = (Guid)SelectedProduct.ProductTypeID;
                }
                catch (Exception) {}
                NotifyPropertyChanged("SelectedProductParameter");
            }
        }

        public ObservableCollection<ProductParametr> _ProductParametrs;

        public ObservableCollection<ProductParametr> ProductParametrs
        {
            get { return _ProductParametrs; }
            set { _ProductParametrs = value;
                NotifyPropertyChanged("ProductParametrs"); }}

        private void AddProductParameter()
        {
            SelectedProductTypeInProductParametr();
            productParameterService.Add(productParameterService.Serialize(SelectedProductParameter));
            AddSelectedProductParametrToProducts(SelectedProductParameter);
            MessageBox.Show("Parameter was added to product of type", "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void DeleteProductParameter()
        {
            MessageBoxResult result = MessageBox.Show("Do you want delete parametr and parametr's value", "Confirmation",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                productParameterService.Delete(productParameterService.Serialize(SelectedProductParameter));
                DeleteProductParameterToProducts(SelectedProductParameter);
                MessageBox.Show("Parameter was deleted", "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UpdateProductParameter()
        {
            SelectedProductTypeInProductParametr();
            productParameterService.Update(productParameterService.Serialize(SelectedProductParameter));
            ProductParametr pr = SelectedProductParameter;
            DeleteProductParameterToProducts(SelectedProductParameter);
            AddSelectedProductParametrToProducts(pr);
            MessageBox.Show("Parameter was updated", "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SelectedProductTypeInProductParametr()
        {
            SelectedProductParameter.ProductType = SelectedProduct.ProductType;
            //SelectedProductParameter.ProductTypeID = (Guid)SelectedProduct.ProductTypeID;
        }

        /// <summary>
        /// // Two rows for adding productparametr to list in the view
        /// </summary>
        private void AddSelectedProductParametrToProducts(ProductParametr productParametr)
        {
            ProductParametrs.Add(productParametr);
            foreach (var it in Products)
            {
                if (productParametr.ProductType == null) { productParametr.ProductType = new ProductType(); }
                if (it.ProductTypeID == productParametr.ProductType.Id)
                {
                    productParametr.ProductType = null;
                    it.ProductType.ProductParametrs.Add(productParametr);
                }
            }
        }

        private void DeleteProductParameterToProducts(ProductParametr dpr)
        {
            foreach (var it in Products.Where(it => it.ProductTypeID == dpr.ProductType.Id))
            {
                it.ProductType.ProductParametrs.Remove(it.ProductType.ProductParametrs.ToList()
                    .Where(a => a.Id == dpr.Id)
                    .ToList().FirstOrDefault());
            }
            ProductParametrs.Remove(ProductParametrs
              .Where(param => param.Id == SelectedProductParameter.Id)
              .ToList().First());
        }
        
        #region Commands
        public ICommand AddProductParameterCommand
        {
            get { return new RelayCommand(c => AddProductParameter()); }
        }

        public ICommand UpdateProductParameterCommand
        {
            get { return new RelayCommand(c => UpdateProductParameter()); }
        }

        public ICommand DeleteProductParameterCommand
        {
            get { return new RelayCommand(c => DeleteProductParameter()); }
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
