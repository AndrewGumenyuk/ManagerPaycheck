using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MngrPaycheck.Entity
{
    [DataContract]
    [KnownType(typeof(ProductType))]
    [Serializable]
    public class ProductType
    {
        public ProductType()
        {
            this.Id = Guid.NewGuid();
            this.Products = new HashSet<Product>();
            this.ProductParametrs = new HashSet<ProductParametr>();
        }

        [Required] [Key]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }


        #region properties
        [DataMember]
        public virtual ICollection<Product> Products { get; set; }

        [DataMember]
        public virtual ICollection<ProductParametr> ProductParametrs { get; set; } 
        #endregion
    }
}
