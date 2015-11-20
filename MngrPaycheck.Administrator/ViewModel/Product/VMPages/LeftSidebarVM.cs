using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MngrPaycheck.Administrator.View;
using MngrPaycheck.Administrator.View.Product;
using MngrPaycheck.Administrator.View.Product.Pages;

namespace MngrPaycheck.Administrator.ViewModel.Product.VMPages
{
    public class LeftSidebarVM
    {
        LSidebar leftSidebar = new LSidebar();
        public LeftSidebarVM()
        {
            //ClickCommand = new RelayCommand(arg => ViewPageEditing());
            //ClickCallMenu = new RelayCommand(arg => OpenRadialMenu());
        }

        public ICommand ClickCommand { get; set; }
        public ICommand ClickCallMenu { get; set; }

    }
}
