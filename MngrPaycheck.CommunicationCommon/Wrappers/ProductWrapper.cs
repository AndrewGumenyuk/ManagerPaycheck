using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.CommunicationCommon.Wrappers
{
    public class ProductWrapper
    {
       public ObservableCollection<Product> CollectionProducts { get; set; }
       public ProductWrapper()
         {
            this.CollectionProducts = new ObservableCollection<Product>();
         }
    }
}
