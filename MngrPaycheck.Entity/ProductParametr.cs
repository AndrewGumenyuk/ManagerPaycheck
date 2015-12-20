using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MngrPaycheck.Entity
{

    [DataContract]
    [KnownType(typeof(ProductParametr))]
    [Serializable]
    public class ProductParametr
    {
        private Guid id;
        private string name;
        private ProductType productType;
        private ProductParametrValue productParametrValue;

        public ProductParametr()
        {
            this.Id = Guid.NewGuid();
        }

        [Required] [Key]
        [DataMember]
        public Guid Id {
            get { return id; }
            set { id = value;
                OnPropertyChanged("Id");}}

        [DataMember]
        public string Name {
            get { return name; }
            set { name = value;
                OnPropertyChanged("Name");}}

        #region properties
        [DataMember]
        public virtual ProductType ProductType {
            get { return productType; }
            set { productType = value;
                OnPropertyChanged("ProductType"); } }

        [DataMember]
        public virtual ProductParametrValue ProductParametrValue {
            get { return productParametrValue; }
            set { productParametrValue = value;
                OnPropertyChanged("ProductParametrValue"); } }

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
