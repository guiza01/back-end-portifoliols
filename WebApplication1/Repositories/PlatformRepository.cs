using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly ProjectPortfolioDBContext _dbContext;

        public PlatformRepository(ProjectPortfolioDBContext portfolioDBContext)
        {
            _dbContext = portfolioDBContext;
        }

        public async Task<PlatformModels> GetById(int id)
        {
            return await _dbContext.Platforms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PlatformModels>> GetAllPlatforms()
        {
            return await _dbContext.Platforms.ToListAsync();
        }

        public async Task<PlatformModels> Add(PlatformModels platform)
        {
            await _dbContext.Platforms.AddAsync(platform);
            await _dbContext.SaveChangesAsync();

            return platform;
        }

        public async Task<PlatformModels> Update(PlatformModels platform, int id)
        {
            var platformById = await GetById(id);

            if (platformById != null)
            {
                platformById.Name = platform.Name;
                _dbContext.Update(platformById);
                await _dbContext.SaveChangesAsync();
            }

            return platformById;
        }

        public async Task<bool> Delete(int id)
        {
            var platformById = await GetById(id);

            if (platformById != null)
            {
                _dbContext.Platforms.Remove(platformById);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
