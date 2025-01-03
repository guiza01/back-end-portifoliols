namespace WebApplication1.Models
{
    public class SegmentModels
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<SegmentProjectModels> SegmentProjects { get; set; }
    }
}
