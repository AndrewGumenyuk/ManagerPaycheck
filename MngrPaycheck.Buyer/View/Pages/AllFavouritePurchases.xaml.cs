using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MngrPaycheck.Buyer.ViewModel.Pages;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Buyer.View.Pages
{
    /// <summary>
    /// Interaction logic for AllFavouritePurchases.xaml
    /// </summary>
    public partial class AllFavouritePurchases : Page
    {
        private AllFavouritePurchasesVM _vm;
        public AllFavouritePurchases(ObservableCollection<Purchase> purchases)
        {
            InitializeComponent();
            _vm = new AllFavouritePurchasesVM(purchases);
            this.DataContext = _vm;
        }
    }
}
