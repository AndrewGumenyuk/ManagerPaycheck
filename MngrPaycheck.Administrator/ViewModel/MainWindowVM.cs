using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MngrPaycheck.Administrator.View;
using MngrPaycheck.Administrator.View.Product;

namespace MngrPaycheck.Administrator.ViewModel
{
    public class MainWindowVM
    {
        public ICommand ClickCommand { get; set; }
        
        public MainWindowVM()
        {
           // ClickCommand = new RelayCommand(arg => ViewFrmEditing());
        }


        //Top1.Navigate(new Top());

        private void ViewFrmEditing()
        {
            MainWindowProduct mainWindowProduct = new MainWindowProduct();
            mainWindowProduct.Show();
        }
    }
}
