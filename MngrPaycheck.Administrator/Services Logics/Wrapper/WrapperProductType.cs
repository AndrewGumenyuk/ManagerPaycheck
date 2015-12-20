using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Administrator.Services_Logics
{
    public class WrapperProductType
    {
       public ObservableCollection<ProductType> CollectionProductTypes { get; set; }
       public WrapperProductType()
        {
            this.CollectionProductTypes = new ObservableCollection<ProductType>();
        }
    }
}
