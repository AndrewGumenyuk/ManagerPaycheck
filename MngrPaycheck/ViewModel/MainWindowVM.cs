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
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.Concrete;
using MngrPaycheck.CommunicationCommon.Concrete.Proxies;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics.SearchProducts;
using MVVMCommon;

namespace MngrPaycheck.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private IGeneralService<Product> _surrogateProduct;
        private IGeneralService<Buyer> _surrogateBuyer;
        private IGeneralService<Purchase> _surrogatePurchase;
        private IGeneralService<PurchaseProduct> _surrogatePurchaseProduct; 

        private OriginatorSearching originator;
        private ProductsHistory history;

        private Purchase purch;
        private PaymentType payType;

        public MainWindowVM()
        {
            _surrogateProduct = new Surrogate<Product>(new ProductServiceProxy());
            Products = _surrogateProduct.Deserialize(_surrogateProduct.GetAll());
            _surrogateBuyer = new Surrogate<Buyer>(new BuyerServiceProxy());
            Buyers = _surrogateBuyer.Deserialize(_surrogateBuyer.GetAll());
            _surrogatePurchase = new Surrogate<Purchase>(new PurchaseServiceProxy());
            _surrogatePurchaseProduct = new Surrogate<PurchaseProduct>(new PurchaseProductServiceProxy());

            originator = new OriginatorSearching();
            history = new ProductsHistory();
            history.History.Push(originator.SaveState(new List<Product>(Products)));

            ProductPurchasesInCheck = new ObservableCollection<PurchaseProduct>();
        }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value;
                OnPropertyChanged("Products"); } }

        private string productIntroduction;
        public string ProductIntroduction
        {
            get { return productIntroduction; }
            set { 
                productIntroduction = value;
                Sorting(productIntroduction);
                OnPropertyChanged("ProductIntroduction"); }
        }

        public void Sorting(string productIntrod)
        {
            List<Product> converList = originator.RestoreState(history.History.Peek());
            List<Product> prods = new List<Product>(Products);
            
            Products.Clear();
            foreach (var pr in converList) { Products.Add(pr); }
            
            char[] charsIntrod =  productIntrod.ToCharArray();
            int count = charsIntrod.Count();
            prods = new List<Product>();
            foreach (var product in Products)
            {
                int hitCount = 0;
                char[] productChars = product.Name.ToCharArray();
                for (int a = 0; a < count; a++)
                {
                    if (charsIntrod[a] == productChars[a]) { hitCount++; }
                }
                if (hitCount != count) { prods.Add(product); }
            }
            foreach (var p in prods) 
                Products.Remove(p);
        }

        public Product _selectedProduct;
        public Product SelectedProduct // It Is selected product in listview
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                if (ProductPurchasesInCheck.Count == 0 && SearchBuyerName != "") { Checkout(); }
                if (value.ProductType != null) { ProductParametrs = new ObservableCollection<ProductParametr>(value.ProductType.ProductParametrs);}

                PurchaseProduct ppr = new PurchaseProduct();
                bool ProductWasAdded = false;
                
                foreach (var item in ProductPurchasesInCheck.Where(item => item.Product.Name == _selectedProduct.Name))
                {
                    item.Units += 1;
                    ppr = item;
                    ProductWasAdded = true;
                }
                if (ProductWasAdded)
                {
                    ProductPurchasesInCheck.Remove(ProductPurchasesInCheck.Where(a => a.Product.Name == ppr.Product.Name).ToList().FirstOrDefault());
                    ProductPurchasesInCheck.Add(ppr);
                }

                if (ProductWasAdded==false)
                {
                    PurchaseProduct prdPurch = new PurchaseProduct()
                    {
                        Product = _selectedProduct,
                        ProductID = _selectedProduct.Id,
                        Cost = _selectedProduct.Cost,
                        Units = 1,
                        Purchase = purch,
                        PurchaseID = purch.Id,
                    };
                    ProductPurchasesInCheck.Add(prdPurch);                   
                }
                value.Units -= 1;
                ProductWasAdded = false;
                SumInCheck = Summing();
                NotifyPropertyChanged("SelectedProduct");
            }
        }

        private float Summing()
        {
            return ProductPurchasesInCheck.Sum(it => it.Product.Cost*it.Units);
        }

        private float sumInCheck;
        public float SumInCheck 
        {
            get { return sumInCheck; }
            set
            {
                sumInCheck = value;
                NotifyPropertyChanged("SumInCheck");
            }
        }

        public PurchaseProduct _selectedProductInCheck;
        public PurchaseProduct SelectedProductInCheck
        {
            get { return _selectedProductInCheck; }
            set
            {
                _selectedProductInCheck = value;
                if (_selectedProductInCheck!=null)
                {
                     ProductPurchasesInCheck.Remove(ProductPurchasesInCheck.Where(a => a.Product.Name == _selectedProductInCheck.Product.Name).ToList().FirstOrDefault());
                }
                NotifyPropertyChanged("SelectedProductInCheck");
            }
        }

        public ObservableCollection<ProductParametr> _ProductParametrs;
        public ObservableCollection<ProductParametr> ProductParametrs
        {
            get { return _ProductParametrs; }
            set
            {
                _ProductParametrs = value;
                NotifyPropertyChanged("ProductParametrs");
            }
        }

        public ObservableCollection<PurchaseProduct> productPurchasesInCheck;
        public ObservableCollection<PurchaseProduct> ProductPurchasesInCheck
        {
            get { return productPurchasesInCheck; }
            set
            {
                productPurchasesInCheck = value;
                NotifyPropertyChanged("ProductsInCheck");
            }
        }


        private ObservableCollection<Buyer> _buyers;
        public ObservableCollection<Buyer> Buyers
        {
            get { return _buyers; }
            set
            {
                _buyers = value;
                OnPropertyChanged("Buyers");
            }
        }

        private string searchbuyerName;
        public string SearchBuyerName
        {
            get { return searchbuyerName; }
            set
            {
                searchbuyerName = value;
                NotifyPropertyChanged("SearchBuyerName");
            }
        }

        #region strings registration new byer
        public string newBuyerName;
        public string NewBuyerName
        {
            get { return newBuyerName; }
            set
            {
                newBuyerName = value;
                OnPropertyChanged("NewBuyerName");
            }
        }

        public string newBuyerLogin;
        public string NewBuyerLogin
        {
            get { return newBuyerLogin; }
            set
            {
                newBuyerLogin = value;
                OnPropertyChanged("NewBuyerLogin");
            }
        }

        private string newBuyerPassword;
        public string NewBuyerPassword
        {
            get { return newBuyerPassword; }
            set
            {
                newBuyerPassword = value;
                OnPropertyChanged("NewBuyerPassword");
            }
        }
        #endregion

        private void HiddenCheckList(ListView btn)
        {
            bool IsCheckIn=false;
            foreach (var buyer in Buyers)
            {
                if (buyer.Name == searchbuyerName)
                {
                    MessageBox.Show("Buyer was found \nName: " + buyer.Name + "\nLogin: " + buyer.Login + "\nDo you want create check for " + buyer.Name + " ?",
                        "Access token",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Information);
                    IsCheckIn = true;
                }
            }
            if (!IsCheckIn)
            {
                MessageBoxResult result = MessageBox.Show("Buyer was not found. Do you want create new Buyer ?", "Access token", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)//Create new buyer
                {
                    btn.Visibility = Visibility.Hidden;
                }
                if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Please, writing Buyer's name", "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private Buyer RegisteredBuyer;
        private void VisibleCheckList(ListView listview)
        {
            listview.Visibility = Visibility.Visible;
            RegisteredBuyer = new Buyer()
            {
                Name = NewBuyerName,
                Login = NewBuyerLogin,
                Password = NewBuyerPassword
            };
            Buyers.Add(RegisteredBuyer);
            MessageBox.Show("Buyer was create !!", "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Checkout()
        {
            payType = new PaymentType()
            {
                Name = "Cash"
            };

            if (RegisteredBuyer == null)
            {
                Buyer buyr = Buyers.Where(brs => brs.Name == SearchBuyerName).ToList().First();
                purch = new Purchase()
                {
                    Favorite = false,
                    PurchaseAdress = "123123213",
                    PurchaseDate = DateTime.Now,
                    SumPurchase = 100213,
                    PaymentType = payType,
                    PaymentTypeID = payType.Id,
                    BuyerID = buyr.Id
                };
            }
            else
            {
                purch = new Purchase()
                {
                    Favorite = false,
                    PurchaseAdress = "123123213",
                    PurchaseDate = DateTime.Now,
                    SumPurchase = 100213,
                    PaymentType = payType,
                    PaymentTypeID = payType.Id,
                    Buyer = RegisteredBuyer,
                    BuyerID = RegisteredBuyer.Id
                };
            }
        }
        private void PrintCheck()
        {
            foreach (var it in ProductPurchasesInCheck)
            {
                it.Product = null;
                it.Purchase.SumPurchase = SumInCheck;
            }
            _surrogatePurchaseProduct.Add(_surrogatePurchaseProduct.Serialize(ProductPurchasesInCheck));
            Clear();
            MessageBox.Show("The purchase was create !!","Access token", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Clear()
        {
            ProductPurchasesInCheck.Clear();
            SearchBuyerName = string.Empty;
            RegisteredBuyer = null;
        }

        #region Commands
        public ICommand HiddenCheckListCommand
        {
            get { return new RelayCommand<ListView>(HiddenCheckList); }
        }

        public ICommand VisibleCheckListCommand
        {
            get { return new RelayCommand<ListView>(VisibleCheckList); }
        }

        public ICommand CheckoutCommand
        {
            get { return new RelayCommand(c => PrintCheck()); }
        }

        public ICommand ClearCommand
        {
            get { return new RelayCommand(c => Clear()); }
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
