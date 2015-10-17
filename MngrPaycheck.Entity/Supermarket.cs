using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class Supermarket
    {
        public Supermarket()
        {
            this.Id = Guid.NewGuid();
            this.Cashiers = new HashSet<Cashier>();
            this.Purchases = new HashSet<Purchase>();
        }
        
        [Required] [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public Guid ProductID { get; set; }


        #region properties
        public virtual ICollection<Cashier> Cashiers { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; } 
        #endregion
    }
}
