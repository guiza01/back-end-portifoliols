using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ProjectPortfolioDBContext _dbContext;

        public LanguageRepository(ProjectPortfolioDBContext portfolioDBContext)
        {
            _dbContext = portfolioDBContext;
        }

        public async Task<LanguageModels> GetById(int id)
        {
            return await _dbContext.Languages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LanguageModels>> GetAllLanguages()
        {
            return await _dbContext.Languages.ToListAsync();
        }

        public async Task<LanguageModels> Add(LanguageModels language)
        {
            await _dbContext.Languages.AddAsync(language);
            await _dbContext.SaveChangesAsync();

            return language;
        }

        public async Task<LanguageModels> Update(LanguageModels language, int id)
        {
            var languageById = await GetById(id);

            if (languageById != null)
            {
                languageById.Name = language.Name;
                _dbContext.Update(languageById);
                await _dbContext.SaveChangesAsync();
            }

            return languageById;
        }

        public async Task<bool> Delete(int id)
        {
            var languageById = await GetById(id);

            if (languageById != null)
            {
                _dbContext.Languages.Remove(languageById);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
