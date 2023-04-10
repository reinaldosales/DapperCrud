using Domain.Entity;
using Domain.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Resources;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        [HttpGet]
        [Route("RecoverAll")]
        public IActionResult RecoverAll()
        {
            try
            {
                var categories = _categoryService.RecoverAll();

                return Ok(new { Result = categories });
            }
            catch (Exception)
            {
                return BadRequest(new { Result = ApiMsg.AnErrorOccurred });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult Create([FromBody] CreateCategoryModel model)
        {
            try
            {
                var category = _categoryService.CreateNewCategory(model);

                return Ok(new { Result = category.Id });
            }
            catch (Exception)
            {
                return BadRequest(new { Result = ApiMsg.AnErrorOccurred });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("RecoverById/{id}")]
        public IActionResult RecoverById(int id)
        {
            try
            {
                var category = _categoryService.RecoverById(id);

                return Ok(new { Result = category });
            }
            catch (Exception)
            {
                return BadRequest(new { Result = ApiMsg.AnErrorOccurred });
            }
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateCategory/{id}")]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryModel updateCategoryModel, int id)
        {
            try
            {
                var category = _categoryService.RecoverById(id);

                if (category is null)
                    return NotFound(new { Result = String.Format(CategoryMsg.CategoryNotFound, id) });

                category.Title = updateCategoryModel.Title;
                category.Description = updateCategoryModel.Description;
                category.Slug = updateCategoryModel.Slug;

                _categoryService.UpdateCategory(category);

                return Ok(new { Result = CategoryMsg.UpdatedCategory });
            }
            catch (Exception)
            {
                return BadRequest(new { Result = ApiMsg.AnErrorOccurred });
            }
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _categoryService.RecoverById(id);

                if (category is null)
                    return NotFound(new { Result = String.Format(CategoryMsg.CategoryNotFound, id) });

                _categoryService.DeleteCategory(category);

                return Ok(new { Result = CategoryMsg.DeletedCategory });
            }
            catch (Exception)
            {
                return BadRequest(new { Result = ApiMsg.AnErrorOccurred });
            }
        }
    }
}