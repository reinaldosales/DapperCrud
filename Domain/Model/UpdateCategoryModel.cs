using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class UpdateCategoryModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
