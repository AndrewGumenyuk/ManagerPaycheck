using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MngrPaycheck.Administrator.ViewModel.Commands;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.Concrete;
using MngrPaycheck.CommunicationCommon.Concrete.Proxies;

namespace MngrPaycheck.Administrator.ViewModel
{
    public class EditiingProductVM:  ViewModelBase
    {
        private IGeneralService<Entity.Product> surrogate;
        public EditiingProductVM()
        {
            Product = new Entity.Product();
            surrogate = new Surrogate<Entity.Product>(new ProductServiceProxy());
            Products = surrogate.Deserialize(surrogate.GetAll());
        }

        private ObservableCollection<Entity.Product> _products;
        public ObservableCollection<Entity.Product> Products
        {
            get { return _products; }
            set { _products = value;
                OnPropertyChanged("Products"); }
        }

        public Entity.Product _product;
        public Entity.Product Product
        {
            get { return _product; }
            set
                { _product = value;
               NotifyPropertyChanged("Product"); }
        }

        private Entity.Product _selectedProduct;
        public Entity.Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                try
                {   Product = new Entity.Product();//To retrieve data from textboxes
                    Product.Id = value.Id;
                    Product.Name = value.Name;
                    Product.Characteristicks = value.Characteristicks;
                    Product.Cost = value.Cost;
                    Product.Description = value.Description;
                    Product.Units = value.Units;}
                catch (Exception){}
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private void AddProduct(object arg)
        {
            Products.Add(Product);
            surrogate.Add(surrogate.Serialize(Product));         
            Product = new Entity.Product();//In order to reset the selected product
        }

        private void DeleteProduct(object args)
        {
            surrogate.Delete(surrogate.Serialize(_selectedProduct));
            Products.Remove(_selectedProduct);
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
            surrogate.Update(surrogate.Serialize(Product));
            Products[i] = Product;
        }
        #region Commands
        private RelayCommand _addProductCommand;
        public RelayCommand AddProductCommand
        {
            get { return _addProductCommand ?? (_addProductCommand = new RelayCommand(AddProduct)); }
        }


        private RelayCommand _deleteProductCommand;
        public RelayCommand DeleteProductCommand
        {
            get { return _deleteProductCommand ?? (_deleteProductCommand = new RelayCommand(DeleteProduct)); }
        }

        private RelayCommand _updateProductCommand;

        public RelayCommand UpdateProductCommand
        {
            get { return _updateProductCommand ?? (_updateProductCommand = new RelayCommand(UpdateProduct)); }
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
