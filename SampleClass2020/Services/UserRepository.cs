using SampleClass2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Services
{
    public class UserRepository : IUser
    {

        private List<User> _ctx { get; set; }

        public UserRepository()
        {
            var ctx = new List<User>
            {
                new User{ UserId=1, FirstName="Francis", LastName="Ibe" },
                new User{ UserId=2, FirstName="Kaosili", LastName="Nwizu"}
            };


            _ctx = ctx;
        }

        public bool AddUser(User model)
        {
            _ctx.Add(model);
            return true;
        }

        public bool DeleteUser(User model)
        {
            var user = _ctx.FirstOrDefault(x => x.UserId == model.UserId);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User GetUserById(int Id)
        {
            return _ctx.FirstOrDefault(x => x.UserId == Id);
        }

        public ICollection<User> GetUsers()
        {
            return _ctx;
        }

        public bool UpdateUser(User model)
        {
            var user = _ctx.FirstOrDefault(x => x.UserId == model.UserId);
            if (user != null)
            {
                user.UserId = model.UserId;
                user.LastName = model.LastName;
                user.FirstName = model.FirstName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
