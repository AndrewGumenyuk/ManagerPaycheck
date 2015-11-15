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
    public class Cashier
    {
        public Cashier()
        {
            this.Id = Guid.NewGuid();
        }

        [Required] [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public int CashiersRoom { get; set; }

        [DataMember]
        public Guid SuperMarketID { get; set; }


        #region properties
        [DataMember]
        public virtual Supermarket Supermarket { get; set; }
        #endregion
    }
}
