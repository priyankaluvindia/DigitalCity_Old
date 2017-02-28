using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkData;
namespace WorkRepo
{
    public class RegistrationRepo
    {
        public async Task<bool> VerifyUser(String username)
        {
            WorkEntities db = new WorkEntities();        
            return await Task.FromResult<bool>( db.USERS.Any(x => x.USERNAME == username));
        }
    }
}
