using Domain.Entity;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserRepository
    {
        public IEnumerable<UserModel> RecoverAll();

        public User Save(UserModel userModel);

        public User RecoverById(int id);

        public void UpdateUser(User user);

        public void DeleteUser(User user);

        public User RecoverUser(string username, string password);
    }
}
