using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MngrPaycheck.Administrator.View;
using MngrPaycheck.Administrator.View.Product;
using MngrPaycheck.Administrator.View.Product.Pages;

namespace MngrPaycheck.Administrator.ViewModel.Product.VMPages
{
    public class LeftSidebarVM
    {
        
        public LeftSidebarVM()
        {
            ClickGoToAddProduct = new RelayCommand(ViewFrmEditing);
        }

        private void ViewFrmEditing()
        {
            //Pages.Navigate(new FrmEditing());
            MainWindowProduct _mainWindowProduct = new MainWindowProduct();
            //_mainWindowProduct.Pages.Navigate(new FrmEditing());
           _mainWindowProduct.Pages.Navigate(new AddType());
        }

        public ICommand ClickGoToAddProduct { get; set; }


    }
}
