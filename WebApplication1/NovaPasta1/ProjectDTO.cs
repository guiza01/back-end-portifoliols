namespace WebApplication1.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public List<string> Languages { get; set; }
        public List<string> Platforms { get; set; }
        public List<string> Segments { get; set; }
    }
}
