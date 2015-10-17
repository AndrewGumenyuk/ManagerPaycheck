using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class PaymentType
    {
        public PaymentType()
        {
            this.Id = Guid.NewGuid();
            this.Purchases = new HashSet<Purchase>();
        }

        [Required] [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }


        #region properties
        public virtual ICollection<Purchase> Purchases { get; set; } 
        #endregion
    }
}
