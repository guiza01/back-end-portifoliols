namespace WebApplication1.Models
{
    public class LanguageModels
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<LanguageProjectModels> LanguageProjects { get; set; }
    }
}
