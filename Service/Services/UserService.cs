using Domain.Entity;
using Domain.Interface;
using Domain.Model;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateNewUser(CreateUserModel createUserModel)
        {
            var userModel = new UserModel()
            {
                Username = createUserModel.Username,
                Password = createUserModel.Password,
                Role = createUserModel.Role,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            };

            return _userRepository.Save(userModel);
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> RecoverAll()
        {
            throw new NotImplementedException();
        }

        public User RecoverById(int id)
        {
            throw new NotImplementedException();
        }

        public User RecoverUser(string username, string password)
            => _userRepository.RecoverUser(username, password);

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
