namespace WebApplication1.Models
{
    public class SegmentProjectModels
    {
        public int ProjectId { get; set; }
        public int SegmentId { get; set; }
        public SegmentModels? Segment { get; set; }
        public ProjectModels? Project { get; set; }
    }
}
