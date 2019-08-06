using OnlineShopping.Database;
using OnlineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineShopping.Services
{
    public class Products
    {
        public List<Product> GetProducts()
        {
            using (var contxt = new CBContext())
            {
                return contxt.Products.Include(x=>x.Category).ToList();
            }                 
        }
        public void SaveProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Find(ID);
            }
        }
        public void updateProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void deleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                var product = context.Products.Find(ID);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
