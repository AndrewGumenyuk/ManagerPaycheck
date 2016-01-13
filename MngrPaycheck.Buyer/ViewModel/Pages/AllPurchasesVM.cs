using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MVVMCommon;

namespace MngrPaycheck.Buyer.ViewModel.Pages
{
    public class AllPurchasesVM : ViewModelBase
    {
        private IGeneralService<Purchase> surrogatePurchase; 

        public Entity.Buyer _selectedBuyer { get; set; }

        public AllPurchasesVM(Entity.Buyer selectedbuyer)
        {
            _selectedBuyer = selectedbuyer;
            InitializationVariables();
        }

        public void InitializationVariables()
        {
            Purchases = new ObservableCollection<Purchase>(_selectedBuyer.Purchases);
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


        private void DoFavourite(DateTime datetime)
        {
            MessageBox.Show("The purchase was added to favourite parchases", "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
            surrogatePurchase = new Surrogate<Purchase>(new PurchaseServiceProxy());

            foreach (var purch in Purchases.Where(purch => purch.PurchaseDate == datetime))
            {
                purch.Favorite = true;
                surrogatePurchase.Update(surrogatePurchase.Serialize(purch));
                return;
            }
        }

        #region Commands

        public ICommand DoFavouriteCommand
        {
            get { return new RelayCommand<DateTime>(DoFavourite); }
        }

        #endregion
    }
}
