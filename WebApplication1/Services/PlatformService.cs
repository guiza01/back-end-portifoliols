using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Services
{
    public class PlatformService
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformService(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public async Task<List<PlatformModels>> GetAllPlatforms()
        {
            return await _platformRepository.GetAllPlatforms();
        }

        public async Task<PlatformModels> GetById(int id)
        {
            var platform = await _platformRepository.GetById(id);
            if (platform == null)
            {
                throw new Exception($"Plataforma com ID {id} não encontrada.");
            }
            return platform;
        }

        public async Task<PlatformModels> Create(PlatformModels platformModel)
        {
            return await _platformRepository.Add(platformModel);
        }

        public async Task<PlatformModels> Update(PlatformModels platformModel, int id)
        {
            var existingPlatform = await _platformRepository.GetById(id);
            if (existingPlatform == null)
            {
                throw new Exception($"Plataforma com ID {id} não encontrada.");
            }

            platformModel.Id = id;
            return await _platformRepository.Update(platformModel, id);
        }

        public async Task<bool> Delete(int id)
        {
            var existingPlatform = await _platformRepository.GetById(id);
            if (existingPlatform == null)
            {
                throw new Exception($"Plataforma com ID  {id}  não encontrada.");
            }

            return await _platformRepository.Delete(id);
        }
    }
}
