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

namespace MngrPaycheck.Buyer.ViewModel.Pages
{
    public class AllFavouritePurchasesVM : ViewModelBase
    {
        private IGeneralService<Purchase> surrogatePurchase;
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

        public AllFavouritePurchasesVM(ObservableCollection<Purchase>  purchases)
        {
            Purchases = new ObservableCollection<Purchase>(purchases.Where(p => p.Favorite == true).ToList());
        }
        private void DontFavourite(DateTime datetime)
        {
            MessageBox.Show("The purchase was deleted from favourite parchases", "Access token", MessageBoxButton.OK, MessageBoxImage.Information);
            surrogatePurchase = new Surrogate<Purchase>(new PurchaseServiceProxy());

            foreach (var purch in Purchases.Where(purch => purch.PurchaseDate == datetime))
            {
                purch.Favorite = false;
                surrogatePurchase.Update(surrogatePurchase.Serialize(purch));
                Purchases.Remove(purch);
                return;
            }
        }

        #region Commands
        public ICommand DontFavouriteCommand
        {
            get { return new RelayCommand<DateTime>(DontFavourite); }
        }
        #endregion
    }
}
