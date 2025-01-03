using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<ProjectModels>> GetAllProjects();
        Task<ProjectModels> GetById(int id);
        Task<ProjectModels> Add(ProjectModels project);
        Task<ProjectModels> Update(ProjectModels project, int id);
        Task<bool> Delete(int id);
    }
}
