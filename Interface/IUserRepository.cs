using HostelControlService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HostelControlService.Interface
{
    internal interface IUserRepository
    {
        void Add(UserModel user);

        void Edit(UserModel user);

        void Remove(string id);

        bool AuthenticateUser(NetworkCredential credential);

        UserModel GetByName(string username);

        UserModel GetById(string id);

        IEnumerable<UserModel> GetAll();

        IEnumerable<UserModel> GetByAccessLevel(int accessLevel);
    }
}
