using Domain.Entity;
using Domain.Model;

namespace Domain.Interface
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryModel> RecoverAll();

        public Category CreateNewCategory(CreateCategoryModel categoryModel);

        public Category RecoverById(int id);

        public void UpdateCategory(Category category);

        public void DeleteCategory(Category category);
    }
}
