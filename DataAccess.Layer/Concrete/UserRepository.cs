using DataAccess.Layer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDb.Entities;

namespace DataAccess.Layer.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _dbcontext;

        public UserRepository(UserDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<User> GetUser(string username)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(u => u.Name == username);
        }
    }
}
