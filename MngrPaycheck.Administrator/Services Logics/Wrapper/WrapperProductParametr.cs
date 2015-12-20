using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Administrator.Services_Logics.Wrapper
{
    public class WrapperProductParametr
    {
      public ObservableCollection<ProductParametr> CollectionProductParametrs { get; set; }
      public WrapperProductParametr()
        {
            this.CollectionProductParametrs = new ObservableCollection<ProductParametr>();
        }
    }
}
