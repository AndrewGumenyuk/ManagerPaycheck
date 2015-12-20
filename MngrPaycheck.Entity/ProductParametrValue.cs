using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Guid productId;
        private Guid productParameterId;
        private string value;
        private Product product;
        private ProductParametr productParametr;

        [Key, ForeignKey("Product"), Required] 
        [DataMember]
        public Guid ProductID {
            get { return productId; }
            set { productId = value;
                OnPropertyChanged("ProductID"); } }

        [Key, ForeignKey("ProductParametr"), Required]
        [DataMember]
        public Guid ProductParameterID { 
            get { return productParameterId; }
            set { productParameterId = value;
                OnPropertyChanged("ProductParameterID"); } }

        #region properties
        [DataMember]
        public virtual Product Product { 
            get { return product; }
            set { product = value;
                OnPropertyChanged("Product");} }

        [DataMember]
        public virtual ProductParametr ProductParametr
        {
            get { return productParametr; }
            set
            {
                productParametr = value;
                OnPropertyChanged("ProductParametr");
            }
        }

        [DataMember]
        public string Value { 
            get { return value; }
            set { this.value = value;
                OnPropertyChanged("Value");} }
        #endregion

        public ProductParametrValue() { }

        protected ProductParametrValue(Product product)
        {
            Product = product;
        }


        public ProductParametrValue(Product product, string value)
            : this(product)
        {
            Value = value;
        }
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
