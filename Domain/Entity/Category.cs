namespace Domain.Entity
{
    public class Category : EntityBase
    {
        public Category(string title, string slug, string description) 
        {
            Title = title;
            Slug = slug;
            Description = description;
        }

        public Category() { }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }
}