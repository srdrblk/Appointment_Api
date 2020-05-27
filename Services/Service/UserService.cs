using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class UserService :BaseService<User>, IUserService
    {
    
        public UserService(DbContext context)  :base( context)
        {
         
        }
    }
}
