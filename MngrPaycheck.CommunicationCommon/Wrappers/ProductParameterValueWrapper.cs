using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.CommunicationCommon.Wrappers
{
    class ProductParameterValueWrapper
    {
        public ObservableCollection<ProductParametrValue> CollectionProductParametrValues { get; set; }
        public ProductParameterValueWrapper()
        {
            this.CollectionProductParametrValues = new ObservableCollection<ProductParametrValue>();
        }
    }
}
