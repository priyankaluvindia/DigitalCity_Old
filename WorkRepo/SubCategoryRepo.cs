using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkData;
using WorkModels;

namespace WorkRepo
{
    public class SubCategoryRepo
    {
        private WorkEntities db = new WorkEntities();

        public async Task<List<SubCategory>> GetSubCategories()
        {
            return await Task.FromResult(db.SUBCATEGORies.Select(x => new SubCategory { SUBCATEGORYID = x.SUBCATEGORYID, NAME = x.NAME, CREATEDON = x.CREATEDON, STATUS = x.STATUS, IMAGEURL = x.IMAGEURL, PRODUCTS = x.PRODUCTS, SYNONYMS = x.SYNONYMS, CATEGORYID = x.CATEGORYID }).ToList());
        }

        public async Task<bool> SaveSubCategory(SubCategory modelSubCategory)
        {
            var subcategory = db.SUBCATEGORies.FirstOrDefault(x => x.SUBCATEGORYID == modelSubCategory.SUBCATEGORYID);
            if (subcategory == null)
            {
                subcategory = new SUBCATEGORY
                {
                    NAME=modelSubCategory.NAME,
                    CREATEDON=DateTime.Now,
                    STATUS="Active",
                    IMAGEURL=modelSubCategory.IMAGEURL,
                    PRODUCTS=0,
                    SYNONYMS=modelSubCategory.SYNONYMS,
                    CATEGORYID=modelSubCategory.CATEGORYID
                };
                db.SUBCATEGORies.Add(subcategory);
            }
            try
            {
                await db.SaveChangesAsync();
                modelSubCategory.SUBCATEGORYID = subcategory.SUBCATEGORYID;
                modelSubCategory.CREATEDON = subcategory.CREATEDON;
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
