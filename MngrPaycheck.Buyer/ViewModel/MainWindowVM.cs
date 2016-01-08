using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.Concrete;
using MngrPaycheck.CommunicationCommon.Concrete.Proxies;
using MngrPaycheck.Entity;
using MVVMCommon;

namespace MngrPaycheck.Buyer.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private IGeneralService<Purchase> _surrogatePurchase;
        private ObservableCollection<Purchase> purchs;
        public MainWindowVM()
        {
            Types = new ObservableCollection<ProductType>();
        }
        

        private void CheckLogin(Window window)
        {
            window.Close();
        }

        private Entity.Buyer selectedBuyer;
        public Entity.Buyer SelectedBuyer
        {
            get { return selectedBuyer; }
            set { selectedBuyer = value;}
        }

        private void GetAllPurchases()
        {
            Purchases = new ObservableCollection<Purchase>(selectedBuyer.Purchases);
            //Types = Purchases.Select(a=>a.)
            foreach (var it in Purchases.Select(a=>a.PurchaseProducts.Select(b=>b.Product.ProductType).ToList()).ToList())
            {
                foreach (var i in it)
                {
                    Types.Add(i);
                }
            }
        }

        private ObservableCollection<Purchase> purchases;
        public ObservableCollection<Purchase> Purchases
        {
            get { return purchases; }
            set
            {
                purchases = value;
                NotifyPropertyChanged("Purchases");
            }
        }

        private ObservableCollection<ProductType> types;

        public ObservableCollection<ProductType> Types
        {
            get { return types; }
            set
            {
                types = value;
                NotifyPropertyChanged("Types");
            }

        }


        #region Commands
        public ICommand AllChecksCommand
        {
            get { return new RelayCommand(c => GetAllPurchases()); }
        }
        
        public ICommand ExitCommand
        {
            get { return new RelayCommand<Window>(CheckLogin); }
        }
        #endregion
    }
}
