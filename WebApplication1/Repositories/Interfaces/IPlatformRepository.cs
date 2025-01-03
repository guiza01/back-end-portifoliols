using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IPlatformRepository
    {
        Task<List<PlatformModels>> GetAllPlatforms();
        Task<PlatformModels> GetById(int id);
        Task<PlatformModels> Add(PlatformModels platform);
        Task<PlatformModels> Update(PlatformModels platform, int id);
        Task<bool> Delete(int id);
    }
}
