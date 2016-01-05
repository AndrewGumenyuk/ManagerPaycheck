using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Logics.SearchProducts
{
    public class MementoProducts
    {
        public List<Product> Products { get; set; }

        public MementoProducts(List<Product> _products)
        {
            this.Products = _products;
        }
    }
}
