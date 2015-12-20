using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Guid productTypeID;
        private string name;
        private ICollection<Product> products;
        private ICollection<ProductParametr> productParametrs;

        public ProductType()
        {
            this.Id = Guid.NewGuid();
            this.Products = new HashSet<Product>();
            this.ProductParametrs = new HashSet<ProductParametr>();
        }

        [Required] [Key]
        [DataMember]
        public Guid Id {
            get { return productTypeID; }
            set
                { productTypeID = value;
                OnPropertyChanged("Id"); }}

        [DataMember]
        public string Name {
            get { return name; }
            set
                { name = value;
                OnPropertyChanged("Name"); }}


        #region properties
        [DataMember]
        public virtual ICollection<Product> Products {
            get { return products; }
            set
                { products = value;
                OnPropertyChanged("Products"); }}

        [DataMember]
        public virtual ICollection<ProductParametr> ProductParametrs {
            get { return productParametrs; }
            set
                { productParametrs = value;
                OnPropertyChanged("ProductParametrs"); }} 
        #endregion

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
