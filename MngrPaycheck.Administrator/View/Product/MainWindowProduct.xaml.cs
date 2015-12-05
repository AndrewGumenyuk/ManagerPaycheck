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
using System.Windows.Shapes;
using MngrPaycheck.Administrator.View.Product.Pages;

namespace MngrPaycheck.Administrator.View.Product
{
    /// <summary>
    /// Interaction logic for MainWindowProduct.xaml
    /// </summary>
    public partial class MainWindowProduct : Window
    {
        public MainWindowProduct()
        {
            InitializeComponent();
            Top1.Navigate(new Top());
            LSidebar.Navigate(new LSidebar());
            //Pages.Navigate(new FrmEditing());
            //Pages.Navigate(new AddParameter());
            Pages.Navigate(new AddType());
            // Pages.Navigate(new AddValueToParameter());
        }
    }
}
