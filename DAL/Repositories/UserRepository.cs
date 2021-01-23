using DAL.Contexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private readonly MySQLContext _ctx;

        public UserRepository()
        {
            _ctx = new MySQLContext();
        }


        public IEnumerable<User> GetAll()
        {
            return _ctx.Users.ToList();
        }



    }
}
