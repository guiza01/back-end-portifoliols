using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectModels>>> GetAllProjects()
        {
            List<ProjectModels> projects = await _projectService.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProjectModels>>> GetById(int id)
        {
            ProjectModels project = await _projectService.GetById(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectModels>> Create([FromBody] ProjectModels projectModel)
        {
            ProjectModels project = await _projectService.Create(projectModel);
            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectModels>> Update([FromBody] ProjectModels projectModel, int id)
        {
            projectModel.Id = id;
            ProjectModels project = await _projectService.Update(projectModel, id);
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectModels>> Delete(int id)
        {
            bool deleted = await _projectService.Delete(id);
            return Ok(deleted);
        }
    }
}
