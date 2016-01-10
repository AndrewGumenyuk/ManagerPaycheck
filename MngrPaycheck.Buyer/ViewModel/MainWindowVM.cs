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
        public MainWindowVM() {}

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

        public void InitializationVariables()
        {
            Purchases = new ObservableCollection<Purchase>(selectedBuyer.Purchases);
            Types = new ObservableCollection<ProductType>();
            Supermarkets = new ObservableCollection<string>();
        }

        private void GetAllPurchases()
        {
            InitializationVariables();
            GetAllSupermarkets();
            foreach (var listTypes in Purchases.Select(a=>a.PurchaseProducts.Select(b=>b.Product.ProductType).ToList()).ToList())
            {
                foreach (var type in listTypes)
                {
                    if (type != null)
                    {
                        bool elemntwas = false;
                        foreach (var typ in Types)
                        {
                            if (typ.Name == type.Name)
                            {
                                elemntwas = true;
                            }
                        }

                        if (elemntwas == false)
                        {
                            Types.Add(type);
                        }
                    }
                }
            }
        }
        private void GetAllSupermarkets()
        {
            foreach (var purchase in Purchases)
            {
                bool adressWasAdd = false;
                foreach (var supermarket in Supermarkets)
                {
                    if (purchase.PurchaseAdress == supermarket)
                    {
                        adressWasAdd = true;
                    }
                }
                if (adressWasAdd == false)
                {
                    Supermarkets.Add(purchase.PurchaseAdress);
                }
            }
        }

        private ObservableCollection<Purchase> purchases;
        public ObservableCollection<Purchase> Purchases
        {
            get { return purchases; }
            set { purchases = value;
                NotifyPropertyChanged("Purchases"); } }

       

        private ObservableCollection<ProductType> types;
        public ObservableCollection<ProductType> Types
        {
            get { return types; }
            set { types = value;
                NotifyPropertyChanged("Types"); } }

        private ObservableCollection<string> supermarkets;
        public ObservableCollection<string> Supermarkets
        {
            get { return supermarkets; }
            set { supermarkets = value;
                NotifyPropertyChanged("Supermarkets"); } } 

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
