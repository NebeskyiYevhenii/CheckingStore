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
        private readonly MSSQLContext _ctx;

        public UserRepository()
        {
            _ctx = new MSSQLContext();
        }


        public IEnumerable<User> GetAll()
        {
            var rez = _ctx.Users.ToList();
            return rez;
        }
        //public IEnumerable<User> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
        



    }
}
