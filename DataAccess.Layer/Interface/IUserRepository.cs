using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDb.Entities;

namespace DataAccess.Layer.Interface
{
    public interface IUserRepository
    {
        public Task<User> GetUser (string username);
    }
}
