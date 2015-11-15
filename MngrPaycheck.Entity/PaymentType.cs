using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    [DataContract]
    public class PaymentType
    {
        public PaymentType()
        {
            this.Id = Guid.NewGuid();
            this.Purchases = new HashSet<Purchase>();
        }

        [Required] [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }


        #region properties
        [DataMember]
        public virtual ICollection<Purchase> Purchases { get; set; } 
        #endregion
    }
}
