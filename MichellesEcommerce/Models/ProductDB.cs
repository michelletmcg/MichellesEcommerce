using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MichellesEcommerce.Models
{
    public static class ProductDB //class is static if you don't need multiple instances
    {
        /// <summary>
        /// Gets all products sorted by product name
        /// </summary>
        public static List<Product> GetAllProducts()
        {
            //using entity framework get a list of products
            //LINQ (Language Integrated Query)

            var db = new CommerceDbContext(); //this does WAHT ???

            //This is what we are trying to do:
            //SELECT * FROM Products ORDER BY Name

            //Method 1: LINQ Query Syntax (is more like SQL)
            List<Product> products = (from p in db.Products orderby p.Name select p).ToList();
            //go grab all my products  order it by Name from the database and put it into a list 


            //Method 2: LINQ Method Syntax
            List<Product> products2 = db.Products.OrderBy(p => p.Name).ToList();

            return products;
        }

        /// <summary>
        /// Add product to the database
        /// </summary>
        /// <param name="p">Product to be added</param>
        public static void AddProduct(Product p)
        {
            //1.Create instance of DBContext class
            var context = new CommerceDbContext();//anytime we access database we need a commerceDB object to work with

            //2. Prepare insert statement
            context.Products.Add(p); //we passed in the p from the parameter
            //we are accessing our Products property and entity framework accesses our database

            //3. Execute pending insert
            context.SaveChanges();
        }
    }
}