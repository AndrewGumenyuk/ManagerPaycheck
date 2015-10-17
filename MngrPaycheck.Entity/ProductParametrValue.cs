using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class ProductParametrValue
    {
        public ProductParametrValue()
        {
            this.Id = Guid.NewGuid();
        }

        [Required] [Key]
        public Guid Id { get; set; }

        public string Value { get; set; }

        public Guid ProductID { get; set; }

        #region properties
        public virtual Product Product { get; set; }
        #endregion
    }
}
