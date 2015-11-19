using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Entity.Annotations;

namespace MngrPaycheck.Entity
{
    [DataContract]
    [KnownType(typeof(Product))]
    [Serializable]
    public class Product : INotifyPropertyChanged
    {
        private Guid productId;
        private string name;
        private float cost;
        private int units;
        private string description;
        private string characteristicks;
        private Guid? productTypeID;
        private ProductType productType;
        private ICollection<ProductParametrValue> productParametrValues;
        private ICollection<Supermarket> supermarkets;
        private ICollection<Purchase> purchases;
        

        public Product()
        {
            this.Id = Guid.NewGuid();
            this.ProductParametrValues = new HashSet<ProductParametrValue>();
            this.Supermarkets = new HashSet<Supermarket>();
            this.Purchases = new HashSet<Purchase>();
        }

        [Required]
        [Key]
        [DataMember]
        public Guid Id
        {
            get { return productId; } 
            set { this.productId = value;
                OnPropertyChanged("Id"); }
        }

        [Required]
        [DataMember]
        public string Name 
        { 
            get { return name; }
            set { this.name = value;
                OnPropertyChanged("Name"); } 
        }

        [Required]
        [DataMember]
        public float Cost
        {
            get { return cost; }
            set { this.cost = value;
              OnPropertyChanged("Cost"); }
        }

        [Required]
        [DataMember]
        public int Units
        {
            get { return units; }
            set { this.units = value;
                OnPropertyChanged("Units"); }
        }

        [Required]
        [DataMember]
        public string Description
        {
            get { return description; }
            set { this.description = value; 
               OnPropertyChanged("Description"); }
        }

        [DataMember]
        public string Characteristicks
        {
            get { return characteristicks; }
            set { this.characteristicks = value;
                OnPropertyChanged("Characteristicks"); }
        }

        [DataMember]
        public Guid? ProductTypeID
        {
            get { return productTypeID; }
            set { this.productTypeID = value;
                OnPropertyChanged("ProductTypeID"); }
        }

        #region  properties
        [DataMember]
        public virtual ProductType ProductType
        {
            get { return productType; }
            set { this.productType = value;
                OnPropertyChanged("ProductType"); }
        }

        [DataMember]
        public virtual ICollection<ProductParametrValue> ProductParametrValues
        {
            get { return productParametrValues; }
            set { this.productParametrValues = value;
                OnPropertyChanged("ProductParametrValues"); }
        }

        [DataMember]
        public virtual ICollection<Supermarket> Supermarkets
        {
            get { return supermarkets; }
            set { this.supermarkets = value;
                OnPropertyChanged("Supermarkets"); }
        }

        [DataMember]
        public virtual ICollection<Purchase> Purchases
        {
            get { return purchases; }
            set { this.purchases = value;
                OnPropertyChanged("Purchases"); }
        } 
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
