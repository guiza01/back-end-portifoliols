using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectModels>> GetAllProjects()
        {
            return await _projectRepository.GetAllProjects();
        }

        public async Task<ProjectModels> GetById(int id)
        {
            var project = await _projectRepository.GetById(id);
            if (project == null)
            {
                throw new Exception($"Projeto com ID {id} não encontrado.");
            }
            return project;
        }

        public async Task<ProjectModels> Create(ProjectModels projectModel)
        {
            return await _projectRepository.Add(projectModel);
        }

        public async Task<ProjectModels> Update(ProjectModels projectModel, int id)
        {
            var existingProject = await _projectRepository.GetById(id);
            if (existingProject == null)
            {
                throw new Exception($"Project with ID {id} not found.");
            }

            projectModel.Id = id;
            return await _projectRepository.Update(projectModel, id);
        }

        public async Task<bool> Delete(int id)
        {
            var existingProject = await _projectRepository.GetById(id);
            if (existingProject == null)
            {
                throw new Exception($"Project with ID {id} not found.");
            }

            return await _projectRepository.Delete(id);
        }
    }
}
