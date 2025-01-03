using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        private readonly ProjectPortfolioDBContext _dbContext;

        public SegmentRepository(ProjectPortfolioDBContext segmentPortfolioDBContext)
        {
            _dbContext = segmentPortfolioDBContext;
        }

        public async Task<SegmentModels> GetById(int id)
        {
            return await _dbContext.Segments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<SegmentModels>> GetAllSegments()
        {
            return await _dbContext.Segments.ToListAsync();
        }

        public async Task<SegmentModels> Add(SegmentModels segment)
        {
            await _dbContext.Segments.AddAsync(segment);
            await _dbContext.SaveChangesAsync();

            return segment;
        }

        public async Task<SegmentModels> Update(SegmentModels segment, int id)
        {
            SegmentModels segmentById = await GetById(id);

            if (segmentById == null)
            {
                throw new Exception($"Segmento com ID: {id} não foi encontrado na base de dados.");
            }

            segmentById.Name = segment.Name;

            _dbContext.Update(segmentById);
            await _dbContext.SaveChangesAsync();

            return segmentById;
        }

        public async Task<bool> Delete(int id)
        {
            SegmentModels segmentById = await GetById(id);

            if (segmentById == null)
            {
                throw new Exception($"Segmento com ID: {id} não foi encontrado na base de dados.");
            }

            _dbContext.Segments.Remove(segmentById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
