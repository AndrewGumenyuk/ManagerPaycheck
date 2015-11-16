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
    [KnownType(typeof(Product))]
    [Serializable]
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
            this.ProductParametrValues = new HashSet<ProductParametrValue>();
            this.Supermarkets = new HashSet<Supermarket>();
            this.Purchases = new HashSet<Purchase>();
        }

        [Required][Key]
        [DataMember]
        public Guid Id { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }

        [Required]
        [DataMember]
        public float Cost { get; set; }

        [Required]
        [DataMember]
        public int Units { get; set; }

        [Required]
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Characteristicks { get; set; }

        [DataMember]
        public Guid? ProductTypeID { get; set; }

        #region  properties
        [DataMember]
        public virtual ProductType ProductType { get; set; }

        [DataMember]
        public virtual ICollection<ProductParametrValue> ProductParametrValues { get; set; }

        [DataMember]
        public virtual ICollection<Supermarket> Supermarkets { get; set; }

        [DataMember]
        public virtual ICollection<Purchase> Purchases { get; set; } 
        #endregion

    }
}
