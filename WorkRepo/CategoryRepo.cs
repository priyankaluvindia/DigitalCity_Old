using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkData;
using WorkModels;
namespace WorkRepo
{
    public class CategoryRepo
    {
        private WorkEntities context = new WorkEntities();
        public async Task<bool> SaveCategory(Category model)
        {
            var category = context.CATEGORIES.FirstOrDefault(x => x.ID == model.ID);
            if (category == null)
            {
                category = new CATEGORy { SYNONYMS=model.SYNONYMS, NAME = model.NAME, CREATEDON = DateTime.Now, STATUS = "Active", IMAGEURL = model.IMAGEURL, PRODUCTS = 0, SUBCATEGORIES = 0 };
                context.CATEGORIES.Add(category);
            }
            try
            {
                await context.SaveChangesAsync();
                model.ID = category.ID;
                model.CREATEDON = category.CREATEDON;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            return await Task.FromResult(context.CATEGORIES.Select(x => new Category { ID = x.ID, CREATEDON = x.CREATEDON, IMAGEURL = x.IMAGEURL, NAME = x.NAME, PRODUCTS = x.PRODUCTS, STATUS = x.STATUS, SUBCATEGORIES = x.SUBCATEGORIES, SYNONYMS=x.SYNONYMS }).ToList());
        }
    }
}
