using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Administrator.Services_Logics.Wrapper
{
    class WrapperProductParameterValue
    {
        public ObservableCollection<ProductParametrValue> CollectionProductParametrValues { get; set; }
        public WrapperProductParameterValue()
        {
            this.CollectionProductParametrValues = new ObservableCollection<ProductParametrValue>();
        }

    }
}
