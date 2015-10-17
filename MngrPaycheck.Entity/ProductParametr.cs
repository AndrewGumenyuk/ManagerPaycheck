using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    public class ProductParametr
    {
        public ProductParametr()
        {
            this.Id = Guid.NewGuid();
        }

        [Required] [Key]
        public Guid Id { get; private set; }

        public string Name { get; set; }


        public Guid ProductTypeID { get; set; }



        #region properties
        public virtual ProductType ProductType { get; set; }
        public virtual ProductParametrValue ProductParametrValue { get; set; }
        #endregion
    }
}
