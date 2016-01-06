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
    [KnownType(typeof(Buyer))]
    [Serializable]
    public class Buyer
    {
        public Buyer()
        {
            this.Id = Guid.NewGuid();
            this.Purchases = new HashSet<Purchase>();
        }

        [Required]
        [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public virtual ICollection<Purchase> Purchases { get; set; } 
    }
}
