using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDb.Entities;

namespace BusinessServices.Layer.Interface
{
    public interface IUserBusiness
    {
        public Task<User> GetUser(string username, string password);
    }
}
