using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WorkModels;
using WorkRepo;
using Newtonsoft.Json;
using System.IO;

namespace Work.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryRepo repo = new CategoryRepo();
        // GET: api/Category
        public  List<Category> Get()
        {
            return repo.GetCategories().Result;
        }

        public String Index(string title,string id) {
            return null;
        }

        // GET: api/Category/5
        public string Get(int id)
        {
            return "value";
        }



        // POST: api/Category
        public async Task<IHttpActionResult> Post()
        {
            HttpPostedFile file = null;
            String location = "";
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                file = HttpContext.Current.Request.Files[0];
                location="/images/categories/"+ Guid.NewGuid() + DateTime.Now.ToString("ddMMyyyyHHmmss") + Path.GetExtension(file.FileName);
            }
       
            Category category = (Category)JsonConvert.DeserializeObject(HttpContext.Current.Request.Form[0], typeof(Category));
       
            if(file!=null)
            {
                category.IMAGEURL = HttpContext.Current.Request.Url.Scheme+"://"+ HttpContext.Current.Request.Url.Authority + "" + location;
            }
           
            if (await repo.SaveCategory(category))
            {
                if (file != null)
                {
                    try
                    {
                        String path = HttpContext.Current.Server.MapPath("~/") + location;
                        file.SaveAs(path);
                    }
                    catch(Exception ex)
                    {

                    }
                }
                return Ok(category);
            }

            else
            {
                return BadRequest("Record can't be saved !!");
            }
        }
    }
}
