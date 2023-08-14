using BusinessServices.Layer.Interface;
using DataAccess.Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDb.Entities;

namespace BusinessServices.Layer.Concrete
{
    public class UserBusiness : IUserBusiness
    {

        private readonly IUserRepository _repository;
        public UserBusiness(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> GetUser(string username, string password){
            
             var user = await _repository.GetUser(username);
            return user;
        }
    }
}
