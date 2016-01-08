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
using MngrPaycheck.Buyer.ViewModel;

namespace MngrPaycheck.Buyer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM _vm;
        public MainWindow(Entity.Buyer ch)
        {
            InitializeComponent();
            _vm = new MainWindowVM();
            _vm.SelectedBuyer = ch;
            DataContext = _vm;
        }
    }
}
