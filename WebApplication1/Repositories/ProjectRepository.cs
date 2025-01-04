using WebApplication1.Repositories.Interfaces;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectPortfolioDBContext _dbContext;

        public ProjectRepository(ProjectPortfolioDBContext projectPortfolioDBContext)
        {
            _dbContext = projectPortfolioDBContext;
        }

        public async Task<ProjectModels> GetById(int id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProjectModels>> GetAllProjects()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<ProjectModels> Add(ProjectModels project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project;
        }

        public async Task<ProjectModels> Update(ProjectModels project, int id)
        {
            var projectById = await GetById(id);

            if (projectById != null)
            {
                projectById.Title = project.Title;
                projectById.Description = project.Description;
                projectById.Link = project.Link;

                _dbContext.Update(projectById);
                await _dbContext.SaveChangesAsync();
            }

            return projectById;
        }

        public async Task<bool> Delete(int id)
        {
            var projectById = await GetById(id);

            if (projectById != null)
            {
                _dbContext.Projects.Remove(projectById);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
