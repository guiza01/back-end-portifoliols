using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Services
{
    public class LanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<List<LanguageModels>> GetAllLanguages()
        {
            return await _languageRepository.GetAllLanguages();
        }

        public async Task<LanguageModels> GetById(int id)
        {
            var language = await _languageRepository.GetById(id);
            if (language == null)
            {
                throw new Exception($"Linguagem com ID {id} não encontrado.");
            }
            return language;
        }

        public async Task<LanguageModels> Create(LanguageModels languageModel)
        {
            return await _languageRepository.Add(languageModel);
        }

        public async Task<LanguageModels> Update(LanguageModels languageModel, int id)
        {
            var existingLanguage = await _languageRepository.GetById(id);
            if (existingLanguage == null)
            {
                throw new Exception($"Linguagem com ID {id} não encontrado.");
            }

            languageModel.Id = id;
            return await _languageRepository.Update(languageModel, id);
        }

        public async Task<bool> Delete(int id)
        {
            var existingLanguage = await _languageRepository.GetById(id);
            if (existingLanguage == null)
            {
                throw new Exception($"Linguagem com ID  {id}  não encontrado.");
            }

            return await _languageRepository.Delete(id);
        }
    }
}
