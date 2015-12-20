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
using MngrPaycheck.Administrator.ViewModel.Product.VMProducts;

namespace MngrPaycheck.Administrator.View.Product.Pages
{
    /// <summary>
    /// Interaction logic for AddType.xaml
    /// </summary>
    public partial class AddType : Page
    {
        private AddTypeVM _vm;
        public AddType()
        {
            InitializeComponent();

            _vm = new AddTypeVM();
           this.DataContext=_vm;
        }
    }
}
