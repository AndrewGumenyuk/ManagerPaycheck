using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;
using MngrPaycheck.ProductServiceReference;
using MngrPaycheck.Services_Logics;

namespace MngrPaycheck.ViewModel
{
    public class MainWindowVM
    {
        private ProductSeviceLogics _productSeviceLogics;

        public MainWindowVM()
        {
            _productSeviceLogics = new ProductSeviceLogics();
        }
        public List<Product> Products
        {
            get { return _productSeviceLogics.Products(); }
        }
    }
}
