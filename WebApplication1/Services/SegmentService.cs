using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Services
{
    public class SegmentService
    {
        private readonly ISegmentRepository _segmentRepository;

        public SegmentService(ISegmentRepository segmentRepository)
        {
            _segmentRepository = segmentRepository;
        }

        public async Task<List<SegmentModels>> GetAllSegments()
        {
            return await _segmentRepository.GetAllSegments();
        }

        public async Task<SegmentModels> GetById(int id)
        {
            var segment = await _segmentRepository.GetById(id);
            if (segment == null)
            {
                throw new Exception($"Segmento com ID {id} não encontrado.");
            }
            return segment;
        }

        public async Task<SegmentModels> Create(SegmentModels segmentModel)
        {
            return await _segmentRepository.Add(segmentModel);
        }

        public async Task<SegmentModels> Update(SegmentModels segmentModel, int id)
        {
            var existingSegment = await _segmentRepository.GetById(id);
            if (existingSegment == null)
            {
                throw new Exception($"Segmento com ID {id} não encontrado.");
            }

            segmentModel.Id = id;
            return await _segmentRepository.Update(segmentModel, id);
        }

        public async Task<bool> Delete(int id)
        {
            var existingSegment = await _segmentRepository.GetById(id);
            if (existingSegment == null)
            {
                throw new Exception($"Segmento com ID  {id}  não encontrado.");
            }

            return await _segmentRepository.Delete(id);
        }
    }
}
