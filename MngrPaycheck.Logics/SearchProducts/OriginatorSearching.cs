using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity;

namespace MngrPaycheck.Logics.SearchProducts
{
    public class OriginatorSearching
    {
        public MementoProducts SaveState(List<Product> _products)
        {
            return new MementoProducts(_products);
        }

        public List<Product> RestoreState(MementoProducts memento)
        {
            return memento.Products;
        }
    }
}
