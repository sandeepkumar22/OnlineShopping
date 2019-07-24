using OnlineShopping.Database;
using OnlineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Services
{
    public class CategoriesService
    {
        public List<Category>GetCategories()
        {
            using (var contxt = new CBContext())
            {
                return contxt.Categories.ToList();
            }                 
        }
        public void SaveCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
