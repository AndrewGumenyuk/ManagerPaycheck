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
using MngrPaycheck.Administrator.View.Product;
using MngrPaycheck.Administrator.ViewModel;

namespace MngrPaycheck.Administrator.View
{
    /// <summary>
    /// Interaction logic for FrmEditing.xaml
    /// </summary>
    public partial class FrmEditing : Page
    {
        private EditiingProductVM _vm;

        public FrmEditing()
        {
            InitializeComponent();

            _vm = new EditiingProductVM();
            this.DataContext = _vm;
        }
    }
}
