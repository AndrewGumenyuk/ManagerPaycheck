using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.Concrete;
using MngrPaycheck.CommunicationCommon.Concrete.Proxies;
using MngrPaycheck.Entity;
using ViewModelBase = MngrPaycheck.Administrator.ViewModel.Commands.ViewModelBase;


namespace MngrPaycheck.Administrator.ViewModel.Product.VMProducts
{
    public class AddTypeVM:  ViewModelBase
    {
        private IGeneralService<Entity.Product> surrogate;
        private IGeneralService<ProductType> surrogateProductType;

        public AddTypeVM()
        {
            SelectedProduct = new Entity.Product();
            SelectedProduct.ProductType = new ProductType();

            surrogate = new Surrogate<Entity.Product>(new ProductServiceProxy());
            Products = surrogate.Deserialize(surrogate.GetAll());

            surrogateProductType = new Surrogate<ProductType>(new ProductTypeServiceProxy());
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

       public void AddProductType(object arg)
       {
            if (SelectedProduct.ProductType == null)
            {
                   Products.Where(prod => prod.Id == SelectedProduct.Id)
                        .Single().ProductType = ProductType;
                   ProductType.Products.Add(SelectedProduct);//Is selected product in listview
                   surrogateProductType.Add(surrogateProductType.Serialize(ProductType));
            }
       }
        
        public void DeleteProductType(object arg)
        {
            ProductType.ProductParametrs = null;
            surrogateProductType.Delete(surrogateProductType.Serialize(ProductType));
            Products.Where(prod => prod.Id == SelectedProduct.Id)
                .Single().ProductType = null;
        }
       
        public void UpdateProductType(object arg)
        {
            Products.Where(prod => prod.Id == SelectedProduct.Id)
                .Single().ProductType = ProductType;
            surrogateProductType.Update(surrogateProductType.Serialize(ProductType));
        }

        #region Commands
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
