using DAL.Repositories.Abstract;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concrete
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(TamirhaneContext context):base(context)
        {

        }
    }
}
