using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MngrPaycheck.Administrator.Services_Logics;
using MngrPaycheck.Administrator.View;
using MngrPaycheck.Administrator.ViewModel.Commands;
using MngrPaycheck.Entity;
using Newtonsoft.Json;

namespace MngrPaycheck.Administrator.ViewModel
{
    public class EditiingProductVM:  ViewModelBase
    {
        private ProductSeviceLogics _productSeviceLogics;
        private ObservableCollection<Entity.Product> _products;
        public Entity.Product _product;

        public EditiingProductVM()
        {
            _productSeviceLogics = new ProductSeviceLogics();
            Products = _productSeviceLogics.Products();
            Product = new Entity.Product();
        }

        public ObservableCollection<Entity.Product> Products
        {
            get { return _products; }
            set { _products = value;
                OnPropertyChanged("Products"); }
        }

        public Entity.Product Product
        {
            get { return _product; }
            set
                { _product = value;
               NotifyPropertyChanged("Product"); }
        }

        private Entity.Product _selectedBook;
        public Entity.Product SelectedProduct
        {
            get { return _selectedBook; }
            set
            {
                try
                {
                    Product = new Entity.Product();//To retrieve data from textboxes
                    Product.Id = value.Id;
                    Product.Name = value.Name;
                    Product.Characteristicks = value.Characteristicks;
                    Product.Cost = value.Cost;
                    Product.Description = value.Description;
                    Product.Units = value.Units;
                }
                catch (Exception){}

                _selectedBook = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private void AddNewBook(object arg)
        {
            Products.Add(Product);
            _productSeviceLogics.AddProduct(_productSeviceLogics.SerializeProduct(Product));         
            Product = new Entity.Product();//In order to reset the selected product
        }

        private void RemoveBook(object args)
        {
            _productSeviceLogics.DeleteProduct(_productSeviceLogics.SerializeProduct(_selectedBook));
            Products.Remove(_selectedBook);
        }

        private void UpdateProduct(object args)
        {
            int i = 0;
            foreach (var item in Products)
            {
                if (item.Id==Product.Id)
                {
                    i++;
                }
            }
            _productSeviceLogics.UpdateProducts(_productSeviceLogics.SerializeProduct(Product));
            Products[i] = Product;
        }

        #region Commands
        private RelayCommand _addBookCommand;
        public RelayCommand AddBookCommand
        {
            get
            {
                return _addBookCommand ?? (_addBookCommand = new RelayCommand(AddNewBook));
            }
        }


        private RelayCommand _removeBookCommand;
        public RelayCommand RemoveBookCommand
        {
            get
            {
                return _removeBookCommand ?? (_removeBookCommand = new RelayCommand(RemoveBook));
            }
        }

        private RelayCommand _updateProductCommand;

        public RelayCommand UpdateProductCommand
        {
            get { return _updateProductCommand ?? (_updateProductCommand = new RelayCommand(UpdateProduct)); }
        }
        #endregion


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Private Methods
        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
        #endregion
    }
}
