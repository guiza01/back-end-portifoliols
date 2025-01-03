using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly PlatformService _platformService;

        public PlatformController(PlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlatformModels>>> GetAllPlatforms()
        {
            List<PlatformModels> platforms = await _platformService.GetAllPlatforms();
            return Ok(platforms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PlatformModels>>> GetById(int id)
        {
            PlatformModels platform = await _platformService.GetById(id);
            return Ok(platform);
        }

        [HttpPost]
        public async Task<ActionResult<PlatformModels>> Create([FromBody] PlatformModels platformModel)
        {
            PlatformModels platform = await _platformService.Create(platformModel);
            return Ok(platform);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlatformModels>> Update([FromBody] PlatformModels platformModel, int id)
        {
            platformModel.Id = id;
            PlatformModels platform = await _platformService.Update(platformModel, id);
            return Ok(platform);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlatformModels>> Delete(int id)
        {
            bool deleted = await _platformService.Delete(id);
            return Ok(deleted);
        }
    }
}
