using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class Cashier
    {
        public Cashier()
        {
            this.Id = Guid.NewGuid();
        }

        [Required] [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CashiersRoom { get; set; }

        public Guid SuperMarketID { get; set; }


        #region properties
        public virtual Supermarket Supermarket { get; set; }
        #endregion
    }
}
