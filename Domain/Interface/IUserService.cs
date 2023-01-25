using Domain.Entity;
using Domain.Model;

namespace Domain.Interface
{
    public interface IUserService
    {
        public IEnumerable<UserModel> RecoverAll();

        public User CreateNewUser(CreateUserModel createUserModel);

        public User RecoverById(int id);

        public void UpdateUser(User user);

        public void DeleteUser(User user);

        public User RecoverUser(string username, string password);

    }
}
