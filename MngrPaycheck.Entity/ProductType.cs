using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class ProductType
    {
        public ProductType()
        {
            this.Id = Guid.NewGuid();
            this.Products = new HashSet<Product>();
            this.ProductParametrs = new HashSet<ProductParametr>();
        }

        [Required] [Key]
        public Guid Id { get; private set; }

        public string Name { get; set; }


        #region properties
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductParametr> ProductParametrs { get; set; } 
        #endregion
    }
}
