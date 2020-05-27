using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class UserProductService : BaseService<Appointment>, IUserProductService
    {
    
        public UserProductService(DbContext context)  :base( context)
        {
         
        }
    }
}
