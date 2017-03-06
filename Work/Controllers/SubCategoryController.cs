using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WorkModels;
using WorkRepo;

namespace Work.Controllers
{
    public class SubCategoryController : ApiController
    {
        private SubCategoryRepo subcategoryRepo = new SubCategoryRepo();

        public List<SubCategory> Get()
        {
            return subcategoryRepo.GetSubCategories().Result;
        }

        public async Task<IHttpActionResult> Post()
        {
            HttpPostedFile file = null;
            String location = "";
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                file = HttpContext.Current.Request.Files[0];
                location = "/images/subcategories/" + Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(file.FileName);
            }
            SubCategory subcategory = (SubCategory)JsonConvert.DeserializeObject(HttpContext.Current.Request.Form[0], typeof(SubCategory));
            if (file != null)
            {
                subcategory.IMAGEURL = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "" + location;
            }
            if (await subcategoryRepo.SaveSubCategory(subcategory))
            {
                if (file != null)
                {
                    try
                    {
                        String path = HttpContext.Current.Server.MapPath("~/") + location;
                        file.SaveAs(path);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return Ok(subcategory);
            }
            else
            {
                return BadRequest("Record Cannot Saved");
            }
        }

    }
}