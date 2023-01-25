using Domain.Entity;
using Domain.Interface;
using Domain.Model;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryModel> RecoverAll()
            => _categoryRepository.RecoverAll();

        public Category CreateNewCategory(CreateCategoryModel createCategoryModel)
        {
            CategoryModel categoryModel = new CategoryModel()
            {
                Description = createCategoryModel.Description,
                Slug = createCategoryModel.Slug,
                Title = createCategoryModel.Title,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = null
            };

            return _categoryRepository.Save(categoryModel);
        }

        public Category RecoverById(int id)
            => _categoryRepository.RecoverById(id);

        public void UpdateCategory(Category category)
            => _categoryRepository.UpdateCategory(category);

        public void DeleteCategory(Category category)
            => _categoryRepository.DeleteCategory(category);

    }
}
