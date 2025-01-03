using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ISegmentRepository
    {
        Task<List<SegmentModels>> GetAllSegments();
        Task<SegmentModels> GetById(int id);
        Task<SegmentModels> Add(SegmentModels segment);
        Task<SegmentModels> Update(SegmentModels segment, int id);
        Task<bool> Delete(int id);
    }
}
