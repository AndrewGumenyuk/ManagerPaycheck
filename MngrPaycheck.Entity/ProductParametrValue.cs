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
    public class ProductParametrValue
    {
        public ProductParametrValue()
        {
            this.Id = Guid.NewGuid();
        }

        [Required] [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public Guid ProductID { get; set; }

        #region properties
        [DataMember]
        public virtual Product Product { get; set; }
        #endregion
    }
}
