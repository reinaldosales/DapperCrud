using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class CreateCategoryModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
