using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Administrator.Services_Logics
{
   public class WrapperProductAdministrator
    {
          public ObservableCollection<Product> CollectionProducts { get; set; }
       public WrapperProductAdministrator()
        {
            this.CollectionProducts = new ObservableCollection<Product>();
        }
    }
}
