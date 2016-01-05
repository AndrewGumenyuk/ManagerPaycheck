using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Logics.SearchProducts
{
    public class ProductsHistory
    {
        public Stack<MementoProducts> History { get; set; }

        public ProductsHistory()
        {
            History = new Stack<MementoProducts>();
        }
    }
}
