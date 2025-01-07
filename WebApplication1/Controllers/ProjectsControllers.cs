using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectPortfolioDBContext _context;

        public ProjectsController(ProjectPortfolioDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            var projects = await _context.Projects
                .Include(p => p.LanguageProjects)
                    .ThenInclude(lp => lp.Language)
                .Include(p => p.PlatformProjects)
                    .ThenInclude(pp => pp.Platform)
                .Include(p => p.SegmentProjects)
                    .ThenInclude(sp => sp.Segment)
                .Select(p => new ProjectDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Link = p.Link,
                    Languages = p.LanguageProjects.Select(lp => lp.Language.Name).ToList(),
                    Platforms = p.PlatformProjects.Select(pp => pp.Platform.Name).ToList(),
                    Segments = p.SegmentProjects.Select(sp => sp.Segment.Name).ToList()
                })
                .ToListAsync();

            return Ok(projects);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            var project = await _context.Projects
                .Include(p => p.LanguageProjects)
                    .ThenInclude(lp => lp.Language)
                .Include(p => p.PlatformProjects)
                    .ThenInclude(pp => pp.Platform)
                .Include(p => p.SegmentProjects)
                    .ThenInclude(sp => sp.Segment)
                .Select(p => new ProjectDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Link = p.Link,
                    Languages = p.LanguageProjects.Select(lp => lp.Language.Name).ToList(),
                    Platforms = p.PlatformProjects.Select(pp => pp.Platform.Name).ToList(),
                    Segments = p.SegmentProjects.Select(sp => sp.Segment.Name).ToList()
                })
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

    }
}
