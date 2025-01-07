namespace WebApplication1.Models
{
    public class PlatformProjectModels
    {
        public int ProjectId { get; set; }
        public int PlatformId { get; set; }

        public PlatformModels? Platform { get; set; }
        public ProjectModels? Project { get; set; }
    }
}
