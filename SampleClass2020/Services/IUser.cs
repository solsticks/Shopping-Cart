using SampleClass2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleClass2020.Services
{
    public interface IUser
    {
        bool AddUser(User model);
        bool UpdateUser(User model);
        bool DeleteUser(User model);
        ICollection<User> GetUsers();
        User GetUserById(int Id);
    }
}
