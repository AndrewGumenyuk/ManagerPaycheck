using System.Collections.ObjectModel;
using MngrPaycheck.Entity;

namespace MngrPaycheck.CommunicationCommon.Wrappers
{
    public class ProductParameterWrapper
    {
        public ObservableCollection<ProductParametr> CollectionProductParametrs { get; set; }public ProductParameterWrapper()
        {
            this.CollectionProductParametrs = new ObservableCollection<ProductParametr>();
        }
    }
}
