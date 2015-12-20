using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
   [DataContract(IsReference = true)]
    public class Supermarket
    {
        public Supermarket()
        {
            this.Id = Guid.NewGuid();
            this.Cashiers = new HashSet<Cashier>();
            this.Purchases = new HashSet<Purchase>();
        }
        
        [Required] [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Adress { get; set; }

        [DataMember]
        public Guid ProductID { get; set; }


        #region properties
        [DataMember]
        public virtual ICollection<Cashier> Cashiers { get; set; }

        [DataMember]
        public virtual Product Product { get; set; }

        [DataMember]
        public virtual ICollection<Purchase> Purchases { get; set; } 
        #endregion
    }
}
