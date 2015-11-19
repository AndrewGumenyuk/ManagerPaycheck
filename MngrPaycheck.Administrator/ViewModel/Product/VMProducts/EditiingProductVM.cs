using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MngrPaycheck.Administrator.Services_Logics;
using MngrPaycheck.Administrator.View;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Administrator.ViewModel
{
    public class EditiingProductVM
    {
        private ProductSeviceLogics _productSeviceLogics;
        private IList<Entity.Product> ListProducts;

        public EditiingProductVM()
        {
            _productSeviceLogics = new ProductSeviceLogics();
            ListProducts = _productSeviceLogics.Products();

            //ClickCommand = new RelayCommand(arg => ViewFrmEditing());

        }
        public IList<Entity.Product> Products
        {
            get { return ListProducts; }
            set { ListProducts = value; }
        }

        public ICommand ClickCommand { get; set; }

        //private void ViewFrmEditing()
        //{
        //    FrmEditing frmEditing = new FrmEditing();
        //    frmEditing.Show();
        //}


        private ICommand mUpdater;

        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
    }
}
