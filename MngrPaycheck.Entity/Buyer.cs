using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    [DataContract]
    [KnownType(typeof(Buyer))]
    [Serializable]
    public class Buyer
    {
        public Buyer()
        {
            this.Id = Guid.NewGuid();
            this.Purchases = new HashSet<Purchase>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } 
    }
}
