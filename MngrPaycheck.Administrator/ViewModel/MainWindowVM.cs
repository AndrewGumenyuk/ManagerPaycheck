using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MngrPaycheck.Administrator.View;
using MngrPaycheck.Administrator.View.Product;
using MVVMCommon;

namespace MngrPaycheck.Administrator.ViewModel
{
    public class MainWindowVM
    {     
        public ICommand ShowProductCommand
        {
            get { return new RelayCommand<Frame>(ShowEditing); }
        }

        private void ShowEditing(Frame obj)
        {
            obj.NavigationService.Navigate(new Uri("View/Product/Pages/Editing.xaml", UriKind.Relative));
        }

        public ICommand ShowProductTypeCommand
        {
            get { return new RelayCommand<Frame>(ShowProductType); }
        }

        private void ShowProductType(Frame obj)
        {
            obj.NavigationService.Navigate(new Uri("View/Product/Pages/AddType.xaml", UriKind.Relative));
        }

        public ICommand ShowParameterCommand
        {
            get { return new RelayCommand<Frame>(ShowParameter); }
        }

        private void ShowParameter(Frame obj)
        {
            obj.NavigationService.Navigate(new Uri("View/Product/Pages/AddParameter.xaml", UriKind.Relative));
        }

        public ICommand ShowValueToParameterCommand
        {
            get { return new RelayCommand<Frame>(ShowValue); }
        }

        private void ShowValue(Frame obj)
        {
            obj.NavigationService.Navigate(new Uri("View/Product/Pages/AddValueToParameter.xaml", UriKind.Relative));
        }
    }
}
