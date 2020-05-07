using AtuApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll(bool All, User user);
        User GetById(int id);
        Role GetByRoleId(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
