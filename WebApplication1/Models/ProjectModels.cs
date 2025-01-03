namespace WebApplication1.Models
{
    public class ProjectModels
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public ICollection<LanguageProjectModels> LanguageProjects { get; set; }
        public ICollection<PlatformProjectModels> PlatformProjects { get; set; }
        public ICollection<SegmentProjectModels> SegmentProjects { get; set; }
    }
}
