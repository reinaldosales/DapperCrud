using Data.Context;
using Domain.Interface;
using Domain.Model;
using System.Data;
using Dapper;
using Domain.Entity;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private IDbConnection? _connection;

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
        {
            var query = @"
                SELECT * FROM [User] WITH(NOLOCK)
                WHERE
                    [DeletedAt] IS NULL AND
                    [Username] = @username AND
                    [Password] = @password
                OPTION(MAXDOP 1);
            ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("username", username);
            parameters.Add("password", password);

            using(_connection = new DBContext().SqlConnection())
            {
                return _connection.QuerySingleOrDefault<User>(
                    sql: query,
                    param: parameters
                );
            }
        }

        public User Save(UserModel userModel)
        {
            var query = @"
                INSERT INTO [User]
                OUTPUT INSERTED.*
                VALUES(@username, @password, @role, @createdAt, @updatedAt, @deletedAt);
            ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("username", userModel.Username);
            parameters.Add("password", userModel.Password);
            parameters.Add("role", userModel.Role);
            parameters.Add("createdAt", userModel.CreatedAt);
            parameters.Add("updatedAt", userModel.UpdatedAt);
            parameters.Add("deletedAt", userModel.DeletedAt);

            using (_connection = new DBContext().SqlConnection())
            {
                return _connection.QuerySingle<User>(
                    sql: query,
                    param: parameters
                );
            }
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
