using System;
using System.Collections.Generic;
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

namespace MngrPaycheck.Buyer.View.Pages
{
    public partial class AllPurchases : Page
    {
        private AllPurchasesVM _vm;
        public AllPurchases(Entity.Buyer buyer)
        {
            InitializeComponent();
            _vm = new AllPurchasesVM(buyer);
            this.DataContext = _vm;
        }
    }
}
