using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Services_Logics
{
   public class WrapperProductUser
    {
       public ObservableCollection<Product> CollectionProducts { get; set; }
         public WrapperProductUser()
        {
            this.CollectionProducts = new ObservableCollection<Product>();
        }
    }
}
