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
        private Guid productTypeID;
        private ProductType productType;

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

        [DataMember]
        public Guid ProductTypeID {
            get { return productTypeID; }
            set { productTypeID = value;
                OnPropertyChanged("ProductTypeID");} }



        #region properties
        [DataMember]
        public virtual ProductType ProductType {
            get { return productType; }
            set { productType = value;
                OnPropertyChanged("ProductType"); } }

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
