using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly LanguageService _languageService;

        public LanguageController(LanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LanguageModels>>> GetAllLanguages()
        {
            List<LanguageModels> languages = await _languageService.GetAllLanguages();
            return Ok(languages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<LanguageModels>>> GetById(int id)
        {
            LanguageModels language = await _languageService.GetById(id);
            return Ok(language);
        }

        [HttpPost]
        public async Task<ActionResult<LanguageModels>> Create([FromBody] LanguageModels languageModel)
        {
            LanguageModels language = await _languageService.Create(languageModel);
            return Ok(language);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LanguageModels>> Update([FromBody] LanguageModels languageModel, int id)
        {
            languageModel.Id = id;
            LanguageModels language = await _languageService.Update(languageModel, id);
            return Ok(language);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LanguageModels>> Delete(int id)
        {
            bool deleted = await _languageService.Delete(id);
            return Ok(deleted);
        }
    }
}
