using System.Windows;
using MngrPaycheck.Administrator.ViewModel;

namespace MngrPaycheck.Administrator.View
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
