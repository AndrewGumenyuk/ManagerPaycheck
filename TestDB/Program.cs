using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MngrPaycheck.Common.DAL.Infrastructure;
using MngrPaycheck.DAL.Context;
using MngrPaycheck.DAL.Repositories;
using MngrPaycheck.DAL.Repositories.Abstract;
using MngrPaycheck.Entity;
using MngrPaycheck.Logics;
using MngrPaycheck.Logics.State;
using MngrPaycheck.Logics.State.Concrete;
using MngrPaycheck.Logics.Strategy.Concrete;
using MngrPaycheck.Logics.WorkingPurchases;

namespace TestDB
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program pr = new Program();

            pr.FillDB();
            //pr.testState();
            Console.WriteLine("OK !");
            Console.ReadKey();
            //IProductRepository _purchaseRepository = new IProductRepository(new MngPaycheckContext());

        }

        public void testState()
        {
            var logicsState = new LogicsState();
            Product product = new Product()
            {
                Name = "Asus",
                Characteristicks = "Super laptop",
                Cost = 1012,
                Description = "It`s a super"
            };

            ProductType productType = new ProductType()
            {
                Name = "Laptop"
            };

            logicsState.SetState(new AddedProductState(logicsState));

            logicsState.AddProductType(productType);

            logicsState.AddProduct(product);
            logicsState.AddProductType(productType);

            //ProductParametrValue productParametrValue = new ProductParametrValue()
            //{
            //    Value = "value",
            //    Product = product
            //};

            //ProductParametr productParametr = new ProductParametr()
            //{
            //    Name = "RAM",
            //    ProductParametrValue = productParametrValue
            //};

            //logicsState.AddProductParametrValue(productParametr, productParametrValue);
            //List<ProductParametr> ListOfProductParametr = new List<ProductParametr>() { productParametr };
            //logicsState.AddProductParametr(ListOfProductParametr);
            //logicsState.AddProductParametrValue(productParametr, productParametrValue);
        }

        public void FillDB()
        {
            using (MngPaycheckContext db = new MngPaycheckContext())
            {
                //WORK WITH PRODUCT
                Product prod = new Product()
                {
                    Name = "Asus",
                    Characteristicks = "Super laptop",
                    Cost = 1012,
                    Description = "It`s a super"
                };
                
                Product prod2 = new Product()
                {
                    Name = "Acer",
                    Characteristicks = "Super laptop",
                    Cost = 2016,
                    Description = "It`s a super"
                };

                ProductType prodType = new ProductType()
                {
                    Name = "Laptop",
                };

                ProductParametrValue productParametrValue = new ProductParametrValue(prod, "5 gb");
                ProductParametr productParametr = new ProductParametr()
                {
                    Name = "Ram",
                    ProductType = prodType,
                    ProductParametrValue = productParametrValue
                };

                prod.ProductType = prodType;

                db.Products.Add(prod);
                db.ProductTypes.Add(prodType);
                db.ProductParametrs.Add(productParametr);
                db.ProductParametrValues.Add(productParametrValue);
                db.SaveChanges();
           

                /////////WORK WITH PURCHASES
                ///////Create one purchase and added two products in this purchase
                /// 
                ///
                /// 
                /// 
                //Create Buyer and add to Buyer purchase
                Buyer buyer = new Buyer()
                {
                    Name = "Andrew",
                    Login = "Andrew@login",
                    Password = "1210",
                };
                db.Buyers.Add(buyer);
                db.SaveChanges();

                Purchase purchase = new Purchase()
                {
                    Favorite = false,
                    PurchaseAdress = "123123213",
                    PurchaseDate = DateTime.Now,
                    SumPurchase = 100213,
                    PaymentType = new PaymentType() { Name = "Cash"},
                    Buyer = buyer
                };

                PurchaseProduct purchaseProduct = new PurchaseProduct()
                {
                    Cost = prod.Cost,
                    Units = 12,
                    Product = prod,
                    Purchase = purchase
                };
                
                PurchaseProduct purchaseProduct2 = new PurchaseProduct()
                {
                    Cost = prod2.Cost,
                    Product = prod2,
                    Purchase = purchase
                };

                db.PurchaseProducts.Add(purchaseProduct);
                db.PurchaseProducts.Add(purchaseProduct2);
                db.SaveChanges();
                //////////////////////

                PaymentType paytype = new PaymentType()
                {
                    Name = "Creditka"
                };

                purchase.PaymentType = paytype;

                db.PaymentTypes.Add(paytype);
                db.SaveChanges();

                foreach (var item in db.Buyers.Select(a=>a.Purchases).ToList())
                {
                    foreach (var it in item.Select(a=>a.Favorite))
                    {
                       Console.WriteLine(it.ToString());
                    }
                }

                //LogicsType<Purchase> payType = new LogicsType<Purchase>(new PaymentTypeStrategy());
                //foreach (var item in payType.Execute(paytype))//получаю список всех елементов, у которых тип == paytype
                //{
                //    Console.WriteLine(item.PurchaseAdress);
                //}

                //Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                //LogicsType<Product> productType = new LogicsType<Product>(new ProductTypeStrategy());
                //foreach (var item in productType.Execute(prodType))
                //{
                //    Console.WriteLine(item.Name);
                //}
            }
            Console.WriteLine("OK!");
        }
    }
}
