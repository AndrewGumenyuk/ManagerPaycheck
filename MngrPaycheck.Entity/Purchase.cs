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
    [KnownType(typeof(Purchase))]
    [Serializable]
    public class Purchase : INotifyPropertyChanged
    {
        private Guid id;
        private Guid buyerId;
        private Buyer buyer;
        private float sumPurchase;
        private DateTime purchaseDate;
        private string purchaseAdress;
        private bool favourite;
        private Guid? supermarketId;
        private Guid paymentTypeId;
        private PaymentType paymentType;
        private Supermarket supermarket;
        private ICollection<PurchaseProduct> purchaseProducts; 

        public Purchase()
        {
            this.Id = Guid.NewGuid();
            this.PurchaseProducts = new HashSet<PurchaseProduct>();
        }
        
        [Required] [Key]
        [DataMember]
        public Guid Id { 
            get { return id; } 
            set { this.id = value; 
                OnPropertyChanged("Id"); } }

        [DataMember]
        public Guid BuyerID { 
            get { return buyerId; }
            set { buyerId = value;
                OnPropertyChanged("BuyerID"); } }

        [DataMember]
        public virtual Buyer Buyer { 
            get { return buyer; }
            set { buyer = value; 
                OnPropertyChanged("Buyer"); } }

        [DataMember]
        public float SumPurchase {
            get { return sumPurchase; }
            set { sumPurchase = value;
                OnPropertyChanged("SumPurchase"); } }

        [DataMember]
        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { purchaseDate = value;
                OnPropertyChanged("PurchaseDate"); } }

        [DataMember]
        public string PurchaseAdress
        {
            get { return purchaseAdress; } 
            set { purchaseAdress = value; 
                OnPropertyChanged("PurchaseAdress"); } }

        [DataMember]
        public bool Favorite { 
            get { return favourite; }
            set { favourite = value;
                OnPropertyChanged("Favorite"); } }

        [DataMember]
        public Guid? SupermarketID
        {
            get { return supermarketId; } 
            set { supermarketId = value; 
                OnPropertyChanged("SupermarketID"); }}

        [DataMember]
        public Guid PaymentTypeID {
            get { return paymentTypeId; }
            set { paymentTypeId = value;
                OnPropertyChanged("PaymentTypeID"); } }

        #region properties

        [DataMember]
        public virtual PaymentType PaymentType
        {
            get { return paymentType; } 
            set { paymentType = value; 
                OnPropertyChanged("PaymentType"); } }

        [DataMember]
        public virtual Supermarket Supermarket { 
            get { return supermarket; } 
            set { supermarket = value; 
                OnPropertyChanged("Supermarket"); } }

        [DataMember]
        public virtual ICollection<PurchaseProduct> PurchaseProducts { 
            get { return purchaseProducts; } 
            set { purchaseProducts = value; 
                OnPropertyChanged("PurchaseProducts"); } } 
        #endregion

        public Purchase DeepCopy()
        {
            //var purchase = ShallowCopy();
            var purchase = new Purchase()
            {
                Favorite = Favorite
            };
            return purchase;
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
