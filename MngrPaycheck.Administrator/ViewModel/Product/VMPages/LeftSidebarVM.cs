using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MngrPaycheck.Administrator.View;
using MngrPaycheck.Administrator.View.Product;

namespace MngrPaycheck.Administrator.ViewModel.Product.VMPages
{
    public class LeftSidebarVM
    {
        public LeftSidebarVM()
        {
            ClickCommand = new RelayCommand(arg => ViewPageEditing());
        }

        public ICommand ClickCommand { get; set; }

        private void ViewPageEditing()
        {
           MainWindowProduct _mainWindowProduct = new MainWindowProduct();
            _mainWindowProduct.Pages.Navigate(new FrmEditing());
        }
    }
}
