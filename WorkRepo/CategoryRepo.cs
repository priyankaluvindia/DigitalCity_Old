using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
                category = new CATEGORy { SYNONYMS = model.SYNONYMS, NAME = model.NAME, CREATEDON = DateTime.Now, STATUS = "Active", IMAGEURL = model.IMAGEURL, PRODUCTS = 0, SUBCATEGORIES = 0 };
                context.CATEGORIES.Add(category);
            }

            try
            {
                await context.SaveChangesAsync();
                model.ID = category.ID;
                model.CREATEDON = category.CREATEDON;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            return await Task.FromResult(context.CATEGORIES.Select(x => new Category { ID = x.ID, CREATEDON = x.CREATEDON, IMAGEURL = x.IMAGEURL, NAME = x.NAME, PRODUCTS = x.PRODUCTS, STATUS = x.STATUS, SUBCATEGORIES = x.SUBCATEGORIES, SYNONYMS = x.SYNONYMS }).ToList());
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await Task.FromResult(context.CATEGORIES.Select(x => new Category { ID = x.ID, CREATEDON = x.CREATEDON, IMAGEURL = x.IMAGEURL, NAME = x.NAME, PRODUCTS = x.PRODUCTS, STATUS = x.STATUS, SUBCATEGORIES = x.SUBCATEGORIES, SYNONYMS = x.SYNONYMS }).FirstOrDefault(e => e.ID == id));
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = context.CATEGORIES.FirstOrDefault(x => x.ID == id);
            if (category != null)
            {
                if ((!String.IsNullOrEmpty(category.IMAGEURL)))
                {
                    String path = HttpContext.Current.Server.MapPath("~/") + category.IMAGEURL.Substring(category.IMAGEURL.IndexOf("images"));
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                }
                List<SUBCATEGORY > subcat=context.SUBCATEGORies.Where(x=>x.CATEGORYID==category.ID).ToList();
                context.SUBCATEGORies.RemoveRange(subcat);
                context.CATEGORIES.Remove(category);
            }

            try
            {
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategory(int id, Category model)
        {
            var category = context.CATEGORIES.FirstOrDefault(x => x.ID == id);
            if (category != null)
            {
                category.ID = model.ID;
                category.NAME = model.NAME;
                if ((!String.IsNullOrEmpty(model.IMAGEURL)) && (!String.IsNullOrEmpty(category.IMAGEURL)) && model.IMAGEURL != category.IMAGEURL)
                {
                    String path = HttpContext.Current.Server.MapPath("~/") + category.IMAGEURL.Substring(category.IMAGEURL.IndexOf("images"));
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                   
                }
                if (!String.IsNullOrEmpty(model.IMAGEURL))
                {
                    category.IMAGEURL = model.IMAGEURL;
                }
                category.SYNONYMS = model.SYNONYMS;
                category.STATUS = model.STATUS;
            }
            try
            {
                await context.SaveChangesAsync();              
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



    }
}
