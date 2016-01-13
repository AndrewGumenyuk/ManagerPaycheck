using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MngrPaycheck.Buyer.View;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.Concrete;
using MngrPaycheck.CommunicationCommon.Concrete.Proxies;
using MngrPaycheck.Entity;
using MVVMCommon;

namespace MngrPaycheck.Buyer.ViewModel
{
    public class LoginVM : ViewModelBase
    {
        private IGeneralService<Entity.Buyer> _surrogateBuyer;
        ObservableCollection<Entity.Buyer> Buyers = new ObservableCollection<Entity.Buyer>(); 
        public LoginVM()
        {
            _surrogateBuyer = new Surrogate<Entity.Buyer>(new BuyerServiceProxy());
            Buyers = _surrogateBuyer.Deserialize(_surrogateBuyer.GetAll());
        }

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                NotifyPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private void CheckLogin(Window window)
        {
            
            foreach (var it in Buyers)
            {
                if (it.Login == Login & it.Password == Password)
                {
                    MainWindow mw = new MainWindow(it);
                    mw.Show();
                    window.Close();
                }
            }
        }
        public ICommand LoginCommand
        {
            get { return new RelayCommand<Window>(CheckLogin); }
        }

    }
}
