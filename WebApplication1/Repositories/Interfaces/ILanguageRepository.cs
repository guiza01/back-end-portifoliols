using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModels>> GetAllLanguages();
        Task<LanguageModels> GetById(int id);
        Task<LanguageModels> Add(LanguageModels language);
        Task<LanguageModels> Update(LanguageModels language, int id);
        Task<bool> Delete(int id);
    }
}
