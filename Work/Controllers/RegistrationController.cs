using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkModels;
using WorkRepo;
namespace Work.Controllers
{
    public class RegistrationController : ApiController
    {
        RegistrationRepo rep = new RegistrationRepo();

        // GET: api/Registration/5
        public string Get(String id)
        {
           if( rep.VerifyUser(id).Result)
            {
                return "Already Taken";
            }
           else
            {
                return "Available";
            }
        }

        // POST: api/Registration
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Registration/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Registration/5
        public void Delete(int id)
        {
        }
    }
}
