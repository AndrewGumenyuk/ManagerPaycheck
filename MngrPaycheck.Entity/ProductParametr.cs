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
    public class ProductParametr
    {
        public ProductParametr()
        {
            this.Id = Guid.NewGuid();
        }

        [Required] [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid ProductTypeID { get; set; }



        #region properties
        [DataMember]
        public virtual ProductType ProductType { get; set; }

        [DataMember]
        public virtual ProductParametrValue ProductParametrValue { get; set; }
        #endregion
    }
}
