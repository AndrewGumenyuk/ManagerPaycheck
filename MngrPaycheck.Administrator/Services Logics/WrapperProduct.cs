using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Administrator.Services_Logics
{
   public class WrapperProduct
    {
       public ObservableCollection<Product> CollectionProducts { get; set; }
       public WrapperProduct()
        {
            this.CollectionProducts = new ObservableCollection<Product>();
        }
    }
}
