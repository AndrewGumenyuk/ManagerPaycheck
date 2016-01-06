using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class PurchaseProduct
    {
        public Guid ProductID { get; set; }
        [DataMember]
        public virtual Product Product { get; set; }
        [DataMember]
        public Guid PurchaseID { get; set; }
        [DataMember]
        public virtual Purchase Purchase { get; set; }
        [DataMember]
        public double Cost { get; set; }
        [DataMember]
        public int Units { get; set; }
    }
}
