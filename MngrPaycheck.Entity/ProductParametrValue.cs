using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{
    [DataContract]
    [KnownType(typeof(ProductParametrValue))]
    [Serializable]
    public class ProductParametrValue
    {
        [Key]
        public Guid ProductID { get; set; }

        public Guid ProductParameterID { get; set; }

        [DataMember]
        public string Value { get; set; }

        protected ProductParametrValue(){}

        protected ProductParametrValue(ProductParametr parameter)
        {
            ProductID = Guid.NewGuid();
            this.ProductParameterID = parameter.Id;
        }

        public ProductParametrValue(ProductParametr parameter, Product product) : this(parameter)
        {
            ProductID = product.Id;
            Product = product;
            Value = parameter.Name;
        }

        public ProductParametrValue(ProductParametr parameter, string value)
            : this(parameter)
        {
            Value = value;
        }

        public ProductParametrValue(ProductParametr parameter, Product product, string value)
            : this(parameter, product)
        {
            Value = value;
        }


        #region properties
        public virtual Product Product { get; set; }

        #endregion
    }
}
