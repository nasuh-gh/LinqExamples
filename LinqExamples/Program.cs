using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="Bilgisayar"},
                new Category{CategoryId=2,CategoryName="Telefon"},
            };

            List<Product> products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Acer Leptop", QuantityPerUnit="32 GB Ram", UnitPrice=10000, UnitsInStock=5},
                new Product{ProductId=2,CategoryId=1,ProductName="Asus Leptop", QuantityPerUnit="16 GB Ram", UnitPrice=8000, UnitsInStock=3},
                new Product{ProductId=3,CategoryId=1,ProductName="Hp Leptop", QuantityPerUnit="8 GB Ram", UnitPrice=6000, UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Samsung Telefon", QuantityPerUnit="4 GB Ram", UnitPrice=5000, UnitsInStock=15},
                new Product{ProductId=5,CategoryId=2,ProductName="Apple Telefon", QuantityPerUnit="4 GB Ram", UnitPrice=8000, UnitsInStock=8},
            };

            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         where p.UnitPrice > 5000
                         orderby p.UnitPrice descending //Büyükten küçüğe sırala
                         select new ProductDto
                         {
                             ProductId = p.ProductId,
                             CategoryName = c.CategoryName,
                             ProductName = p.ProductName,
                             UnitPrice = p.UnitPrice
                         };

            foreach (var productDto in result)
            {
                //Araya boşluk koymak şart yoksa üsüste geldiği için jainlenen kısmı göremiyorsun
                //Console.WriteLine(productDto.ProductName + " - " + productDto.CategoryName);
                //Diğer yazım şekli
                Console.WriteLine("{0}---{1}", productDto.ProductName, productDto.CategoryName);
            }

        }
    }

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class ProductDto
    {
        public int ProductId { get; set; }//Product tablosunda
        public string CategoryName { get; set; }//Category tablosunda
        public string ProductName { get; set; }//Product tablosunda
        public decimal UnitPrice { get; set; }//Product tablosunda

    }

}
