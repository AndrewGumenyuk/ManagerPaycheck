using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class PurchaseProduct
    {
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

        public Guid PurchaseID { get; set; }
        public virtual Purchase Purchase { get; set; }

        public double Cost { get; set; }
        public int Units { get; set; }
    }
}
