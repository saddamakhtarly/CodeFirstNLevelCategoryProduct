using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirst.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }    
        public Category Categories{ get; set; }

    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
    public class MyContext : DbContext
    {
        public MyContext() : base("dbconnection")
        {

        }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Product> Products  { get; set; }


    }
}
