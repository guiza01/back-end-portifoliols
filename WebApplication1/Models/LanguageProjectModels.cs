namespace WebApplication1.Models
{
    public class LanguageProjectModels
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int LanguageId { get; set; }

        public LanguageModels? Language { get; set; }
        public ProjectModels? Project { get; set; }
    }
}
