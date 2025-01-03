using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly SegmentService _segmentService;

        public SegmentController(SegmentService segmentService)
        {
            _segmentService = segmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SegmentModels>>> GetAllSegments()
        {
            List<SegmentModels> segments = await _segmentService.GetAllSegments();
            return Ok(segments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SegmentModels>>> GetById(int id)
        {
            SegmentModels segment = await _segmentService.GetById(id);
            return Ok(segment);
        }

        [HttpPost]
        public async Task<ActionResult<SegmentModels>> Create([FromBody] SegmentModels segmentModel)
        {
            SegmentModels segment = await _segmentService.Create(segmentModel);
            return Ok(segment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SegmentModels>> Update([FromBody] SegmentModels segmentModel, int id)
        {
            segmentModel.Id = id;
            SegmentModels segment = await _segmentService.Update(segmentModel, id);
            return Ok(segment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SegmentModels>> Delete(int id)
        {
            bool deleted = await _segmentService.Delete(id);
            return Ok(deleted);
        }
    }
}
