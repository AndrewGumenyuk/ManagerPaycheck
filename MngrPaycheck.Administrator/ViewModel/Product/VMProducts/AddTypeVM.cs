using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MngrPaycheck.Administrator.Services_Logics;
using MngrPaycheck.Administrator.ViewModel.Commands;
using MngrPaycheck.Entity;
using Newtonsoft.Json;
using ViewModelBase = MngrPaycheck.Administrator.ViewModel.Commands.ViewModelBase;


namespace MngrPaycheck.Administrator.ViewModel.Product.VMProducts
{
    public class AddTypeVM:  ViewModelBase
    {
        private ProductSeviceLogics _productSeviceLogics;
        private ProductTypeServiceLogics _productTypeServiceLogics;

        private ObservableCollection<Entity.Product> _products;

        public AddTypeVM()
        {
            _productSeviceLogics = new ProductSeviceLogics();
            _productTypeServiceLogics = new ProductTypeServiceLogics();

            Products = _productSeviceLogics.Products();
            SelectedProduct = new Entity.Product();
            SelectedProduct.ProductType = new ProductType();
        }

        public ProductType _productType;
        public ProductType ProductType
        {
            get { return _productType; }
            set
            {
                try
                {
                    _productType = new ProductType();
                    _productType.Name = value.Name;
                    _productType.Id = value.Id;
                    _productType.ProductParametrs = value.ProductParametrs;
                }
                catch (Exception)
                {
                    Console.WriteLine("Oops !!!");
                }
                NotifyPropertyChanged("ProductType");
            }
        }

        public Entity.Product _selectedProduct;
        public Entity.Product SelectedProduct // It Is selected product in listview
        {
            get { return _selectedProduct; }
            set { ProductType = value.ProductType;
                _selectedProduct = value;
                NotifyPropertyChanged("SelectedProduct"); }
        }
        
        ObservableCollection<Entity.Product> _Products;
        public ObservableCollection<Entity.Product> Products
        {
            get { return _Products; }
            set {_Products = value;
                OnPropertyChanged("Products"); }
        }

       void AddProductType(object arg)
       {
            if (SelectedProduct.ProductType == null)
            {
                   Products.Where(prod => prod.Id == SelectedProduct.Id)
                        .Single().ProductType = ProductType;
                   ProductType.Products.Add(SelectedProduct);//Is selected product in listview
                   _productTypeServiceLogics.AddProductType(_productTypeServiceLogics.SerializeProduct(ProductType));
            }
       }
        
        void DeleteProductType(object arg)
        {
            _productTypeServiceLogics.DeleteProduct(_productTypeServiceLogics.SerializeProduct(ProductType));
            Products.Where(prod => prod.Id == SelectedProduct.Id)
                .Single().ProductType = null;
        }
       
        void UpdateProductType(object arg)
        {
            Products.Where(prod => prod.Id == SelectedProduct.Id)
                .Single().ProductType = ProductType;
            _productTypeServiceLogics.UpdateProductTypes(_productTypeServiceLogics.SerializeProduct(ProductType));
        }


        private RelayCommand _addProductTypeCommand;
        public RelayCommand AddProductTypeCommand
        {
            get { return _addProductTypeCommand ?? (_addProductTypeCommand = new RelayCommand(AddProductType)); }
        }

        private RelayCommand _deleteProductTypeCommand;
        public RelayCommand DeleteProductTypeCommand
        {
            get { return _deleteProductTypeCommand ?? (_deleteProductTypeCommand = new RelayCommand(DeleteProductType)); }
        }

        private RelayCommand _updateProductTypeCommand;
        public RelayCommand UpdateProductTypeCommand
        {
            get { return _updateProductTypeCommand ?? (_updateProductTypeCommand = new RelayCommand(UpdateProductType)); }
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
