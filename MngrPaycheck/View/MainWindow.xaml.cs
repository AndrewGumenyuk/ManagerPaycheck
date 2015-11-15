using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MngrPaycheck.Entity;
using MngrPaycheck.ProductServiceReference;
using MngrPaycheck.Services_Logics;
using MngrPaycheck.ViewModel;
using Newtonsoft.Json;
using ProductService;


namespace MngrPaycheck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVM _vm;

        public MainWindow()
        {
            InitializeComponent();

            _vm = new MainWindowVM();
            this.DataContext = _vm;
        }
    }
}
