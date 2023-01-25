using Domain.Entity;
using Domain.Model;

namespace Domain.Interface
{
    public interface ICategoryRepository
    {
        public IEnumerable<CategoryModel> RecoverAll();

        public Category Save(CategoryModel categoryModel);

        public Category RecoverById(int id);

        public void UpdateCategory(Category category);

        public void DeleteCategory(Category category);
    }
}
