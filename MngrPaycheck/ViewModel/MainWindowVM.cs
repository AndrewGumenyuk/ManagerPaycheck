﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MngrPaycheck.CommunicationCommon.Abstract;
using MngrPaycheck.CommunicationCommon.Concrete;
using MngrPaycheck.CommunicationCommon.Concrete.Proxies;
using MngrPaycheck.Entity;
using MngrPaycheck.Interpreter;
using MngrPaycheck.Interpreter.Abstract;
using MngrPaycheck.Interpreter.Expressions;
using MngrPaycheck.Logics.SearchProducts;
using MVVMCommon;

namespace MngrPaycheck.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private IGeneralService<Product> surrogate;
        private OriginatorSearching originator;
        private ProductsHistory history;

        public MainWindowVM()
        {
            surrogate = new Surrogate<Product>(new ProductServiceProxy());
            Products = surrogate.Deserialize(surrogate.GetAll());
            
            originator = new OriginatorSearching();
            history = new ProductsHistory();
            history.History.Push(originator.SaveState(new List<Product>(Products)));

            ProductsInCheck = new ObservableCollection<Product>();
        }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value;
                OnPropertyChanged("Products"); } }

        private string productIntroduction;
        public string ProductIntroduction
        {
            get { return productIntroduction; }
            set { 
                productIntroduction = value;
                Sorting(productIntroduction);
                OnPropertyChanged("ProductIntroduction"); }
        }

        public void Sorting(string productIntrod)
        {
            List<Product> converList = originator.RestoreState(history.History.Peek());
            List<Product> prods = new List<Product>(Products);
            
            Products.Clear();
            foreach (var pr in converList) { Products.Add(pr); }
            
            char[] charsIntrod =  productIntrod.ToCharArray();
            int count = charsIntrod.Count();
            prods = new List<Product>();
            foreach (var product in Products)
            {
                int hitCount = 0;
                char[] productChars = product.Name.ToCharArray();
                for (int a = 0; a < count; a++)
                {
                    if (charsIntrod[a] == productChars[a]) { hitCount++; }
                }
                if (hitCount != count) { prods.Add(product); }
            }
            foreach (var p in prods) 
                Products.Remove(p);
        }

        public Product _selectedProduct;
        public Product SelectedProduct // It Is selected product in listview
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                if (value.ProductType != null)
                {
                    ProductParametrs = new ObservableCollection<ProductParametr>(value.ProductType.ProductParametrs);
                }

                bool ProductWasAdded = false;
                foreach (var item in ProductsInCheck)
                {
                    if (item.Name == _selectedProduct.Name)
                    {
                        item.Units += 1;
                        ProductWasAdded = true;
                    }
                }

                if (ProductWasAdded==false)
                {
                    Product pr = _selectedProduct;
                    pr.Units = 1;
                    ProductsInCheck.Add(pr);
                }

                if (ProductsInCheck.Count==0)
                {
                    Product pr = _selectedProduct;
                    pr.Units = 1;
                    ProductsInCheck.Add(pr);
                }
                ProductWasAdded = false;
                //SumInCheck();
                NotifyPropertyChanged("SelectedProduct");
            }
        }

        public float SumInCheck()
        {
            //float sum=0;
            //foreach (var it in ProductsInCheck)
            //{
            //    sum += it.Cost;
            //}
            Context context = new Context();
            context.SetVariable("CountOfProducts",10);
            context.SetVariable("Price", 100);
            context.SetVariable("Sum",200);

            IExpression expression = new SubtractExpression(new AddExpression(new NumberExpression("CountOfProducts"), new NumberExpression("Price")), new NumberExpression("Sum"));
            return expression.Interpret(context);
        }

        private float _summingCheck;
        public float SummingCheck
        {
            get { return _summingCheck; }
            set
            {
                _summingCheck = value;
                foreach (var it in ProductsInCheck)
                {
                    _summingCheck += it.Cost*it.Units;
                }
                NotifyPropertyChanged("SummingCheck");
            }
        }

        public Product _selectedProductInCheck;

        public Product SelectedProductInCheck
        {
            get { return _selectedProductInCheck; }
            set
            {
                _selectedProductInCheck = value;

                ProductsInCheck.Remove(_selectedProductInCheck);
                NotifyPropertyChanged("SelectedProductInCheck");
            }
        }


        public ObservableCollection<ProductParametr> _ProductParametrs;
        public ObservableCollection<ProductParametr> ProductParametrs
        {
            get { return _ProductParametrs; }
            set
            {
                _ProductParametrs = value;
                NotifyPropertyChanged("ProductParametrs");
            }
        }

        public ObservableCollection<Product> productsInCheck;

        public ObservableCollection<Product> ProductsInCheck
        {
            get { return productsInCheck; }
            set
            {
                productsInCheck = value;
                NotifyPropertyChanged("ProductsInCheck");
            }
        }

        private void AddProductParameter()
        {

        }

        #region Commands
        public ICommand AddProductParameterCommand
        {
            get { return new RelayCommand(c => AddProductParameter()); }
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
}
