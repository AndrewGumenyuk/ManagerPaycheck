using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
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
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Cost { get; set; }

        [Required]
        public int Units { get; set; }

        [Required]
        public string Description { get; set; }

        public string Characteristicks { get; set; }

        public Guid? ProductTypeID { get; set; }

        #region  properties
        
        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<ProductParametrValue> ProductParametrValues { get; set; }
        public virtual ICollection<Supermarket> Supermarkets { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; } 
        #endregion

    }
}
