using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ServiceModel;
using System.Timers;
using MngrPaycheck.Administrator.Callbacks;
using MngrPaycheck.Administrator.Callbacks.ClientsEventArg;
using MngrPaycheck.Administrator.ProductServiceRef;
using MngrPaycheck.Administrator.ViewModel.Commands;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.Concrete;
using MngrPaycheck.CommunicationCommon.Concrete.Proxies;
using Newtonsoft.Json;
using ClientNotifiedEventArgs = MngrPaycheck.Administrator.Callbacks.ClientsEventArg.ClientNotifiedEventArgs;

namespace MngrPaycheck.Administrator.ViewModel
{
    public class EditiingProductVM:  ViewModelBase
    {
        private IGeneralService<Entity.Product> surrogate;
        private Guid clientId;
        private ProductRepositoryServiceClient chatServiceClient;
        private InstanceContext instanceContext;

        public EditiingProductVM()
        {
            Product = new Entity.Product();
            surrogate = new Surrogate<Entity.Product>(new ProductServiceProxy());
            Products = surrogate.Deserialize(surrogate.GetAll());
            Wnd_Loaded();
        }

        private ObservableCollection<Entity.Product> _products;
        public ObservableCollection<Entity.Product> Products
        {
            get { return _products; }
            set { _products = value;
                OnPropertyChanged("Products"); }
        }

        public Entity.Product _product;
        public Entity.Product Product
        {
            get { return _product; }
            set
                { _product = value;
               NotifyPropertyChanged("Product"); }
        }

        private Entity.Product _selectedProduct;
        public Entity.Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                try
                {   Product = new Entity.Product();//To retrieve data from textboxes
                    Product.Id = value.Id;
                    Product.Name = value.Name;
                    Product.Characteristicks = value.Characteristicks;
                    Product.Cost = value.Cost;
                    Product.Description = value.Description;
                    Product.Units = value.Units;}
                catch (Exception){}
                _selectedProduct = value;
                OnPropertyChanged("SelectedProduct");
            }
        }

        private void AddProduct(object arg)
        {
            CustomerNotification(surrogate.Serialize(Product));

            Products.Add(Product);
            surrogate.Add(surrogate.Serialize(Product));         
            Product = new Entity.Product();//In order to reset the selected product
        }

        private void DeleteProduct(object args)
        {
            surrogate.Delete(surrogate.Serialize(_selectedProduct));
            Products.Remove(_selectedProduct);
        }

        private void UpdateProduct(object args)
        {
            int i = 0;
            foreach (var item in Products)
            {
                if (item.Id==Product.Id)
                {
                    i++;
                }
            }
            surrogate.Update(surrogate.Serialize(Product));
            Products[i] = Product;
        }

        /// <summary>
        /// Initializes the service client and subscribes to the server. 
        /// </summary>
        /// <param name="sender">Main window.</param>
        /// <param name="e">Ignored.</param>
        private void Wnd_Loaded()
        {
            ProductRepositoryServiceCallback chatServiceCallback = new ProductRepositoryServiceCallback();
            chatServiceCallback.ClientNotified += ChatServiceCallback_ClientNotified;

            instanceContext = new InstanceContext(chatServiceCallback);
            chatServiceClient = new ProductRepositoryServiceClient(instanceContext);

            try
            {
                clientId = chatServiceClient.Subscribe();
            }
            catch
            {
                // TODO: Handle exception.
            }

            // Set up the timer
            Timer timer = new Timer(300000);
            timer.Elapsed +=
            (
                (object o, ElapsedEventArgs args) =>
                {
                    try
                    {
                        if (chatServiceClient.State == CommunicationState.Faulted)
                        {
                            chatServiceClient.Abort();
                            chatServiceClient = new ProductRepositoryServiceClient(instanceContext);
                        }

                        chatServiceClient.KeepConnection();
                    }
                    catch
                    {
                        // TODO: Handle exception.
                    }
                }
            );
        }

        /// <summary>
        /// Receives a message from the server. Adds the message to the
        /// text box.
        /// </summary>
        /// <param name="sender">ChatServiceCallback object.</param>
        /// <param name="e">Contains the message from the server.</param>
        private void ChatServiceCallback_ClientNotified(object sender, ClientNotifiedEventArgs e)
        {
            //conferenceTbx.Text += e.Message;
            Entity.Product pr = JsonConvert.DeserializeObject<ProductWrapp>(e.Message).Product;
            Products.Add(pr);
        }

        /// <summary>
        /// Sends the message to the server.
        /// </summary>
        /// <param name="sender">Send button.</param>
        /// <param name="e">Ignored.</param>
        private void CustomerNotification(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                try
                {
                    if (chatServiceClient.State == CommunicationState.Faulted)
                    {
                        chatServiceClient.Abort();
                        chatServiceClient = new ProductRepositoryServiceClient(instanceContext);
                    }

                    chatServiceClient.SendMessage(clientId, msg);

                   //messageTbx.Text = string.Empty;
                }
                catch
                {
                    // TODO: Handle exception
                }
            }
        }


        #region Commands
        private RelayCommand _addProductCommand;
        public RelayCommand AddProductCommand
        {
            get { return _addProductCommand ?? (_addProductCommand = new RelayCommand(AddProduct)); }
        }


        private RelayCommand _deleteProductCommand;
        public RelayCommand DeleteProductCommand
        {
            get { return _deleteProductCommand ?? (_deleteProductCommand = new RelayCommand(DeleteProduct)); }
        }

        private RelayCommand _updateProductCommand;

        public RelayCommand UpdateProductCommand
        {
            get { return _updateProductCommand ?? (_updateProductCommand = new RelayCommand(UpdateProduct)); }
        }
        #endregion
        #region Events
        public event PropertyChangedEventHandler ProductPropertyChanged;
        #endregion
        #region Private Methods
        private void OnPropertyChanged(string propertyChanged)
        {
            if (ProductPropertyChanged != null)
                ProductPropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
        #endregion
    }

    public delegate void ClientNotifiedEventHandler(object sender, ClientNotifiedEventArgs e);

    public class ProductWrapp
    {
        public Entity.Product Product { get; set; }
        public ProductWrapp()
        {
            this.Product = new Entity.Product();
        }
    }

}
