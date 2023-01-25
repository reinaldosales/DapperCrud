using Data.Context;
using Domain.Interface;
using Domain.Model;
using System.Data;
using Dapper;
using Domain.Entity;

namespace Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private IDbConnection? _connection;

        public IEnumerable<CategoryModel> RecoverAll()
        {
            var query = @"
                SELECT * FROM [Category] WITH(NOLOCK)
                WHERE
                    [DeletedAt] IS NULL
                ORDER BY 1 DESC
                OPTION(MAXDOP 1);
            ";

            using (_connection = new DBContext().SqlConnection())
            {
                return _connection.Query<CategoryModel>(
                    sql: query
                ).ToList();
            }
        }

        public Category Save(CategoryModel categoryModel)
        {
            var query = @"
                INSERT INTO [Category]
                OUTPUT INSERTED.*
                VALUES (@title, @slug, @description, @createdAt, @updatedAt, @deletedAt);
            ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("title", categoryModel.Title);
            parameters.Add("slug", categoryModel.Slug);
            parameters.Add("description", categoryModel.Description);
            parameters.Add("createdAt", categoryModel.CreatedAt);
            parameters.Add("updatedAt", categoryModel.UpdatedAt);
            parameters.Add("deletedAt", categoryModel.DeletedAt);

            using (_connection = new DBContext().SqlConnection())
            {
                return _connection.QuerySingle<Category>(
                    sql: query,
                    param: parameters
                );
            }
        }

        public Category RecoverById(int id)
        {
            var query = @"
                SELECT * FROM [Category] WITH(NOLOCK)
                WHERE 
                    [DeletedAt] IS NULL AND
                    [Id] = @id 
                OPTION(MAXDOP 1);
            ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);

            using (IDbConnection _connection = new DBContext().SqlConnection())
            {
                return _connection.QuerySingleOrDefault<Category>(
                    sql: query,
                    param: parameters
                );
            }
        }

        public void UpdateCategory(Category category)
        {
            var query = @"
                UPDATE [Category]
                SET [Title] = @title, [Slug] = @slug, [Description] = @description, [UpdatedAt] = @updatedAt
                WHERE
                    Id = @id
            ";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("title", category.Title);
            parameters.Add("slug", category.Slug);
            parameters.Add("description", category.Description);
            parameters.Add("updatedAt", DateTime.Now);
            parameters.Add("id", category.Id);

            using (_connection = new DBContext().SqlConnection())
            {
                _connection.Execute(
                    sql: query,
                    param: parameters
                );
            }
        }

        /* Método criado para testar execução de stored procedures com o ORM. */
        public Category RecoverByIdWithStoredProcedure(int id)
        {
            using (_connection = new DBContext().SqlConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", id);

                return _connection.QuerySingleOrDefault<Category>(
                    sql: "RecoverCategoryById",
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void DeleteCategory(Category category)
        {
            var query = @"
                UPDATE [Category]
                SET [DeletedAt] = @deletedAt
                WHERE
                    Id = @id
            ";

            using (_connection = new DBContext().SqlConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("deletedAt", DateTime.Now);
                parameters.Add("Id", category.Id);

                _connection.Execute(
                    sql: query,
                    param: parameters
                );
            }
        }
    }
}
