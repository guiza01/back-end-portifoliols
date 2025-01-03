namespace WebApplication1.Models
{
    public class PlatformModels
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<PlatformProjectModels> PlatformProjects { get; set; }
    }
}
