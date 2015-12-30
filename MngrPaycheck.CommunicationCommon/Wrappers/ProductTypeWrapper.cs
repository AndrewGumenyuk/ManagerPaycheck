using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.CommunicationCommon.Wrappers
{
    public class ProductTypeWrapper
    {
        public ObservableCollection<ProductType> CollectionProductTypes { get; set; }
        public ProductTypeWrapper()
        {
            this.CollectionProductTypes = new ObservableCollection<ProductType>();
        }
    }
}
