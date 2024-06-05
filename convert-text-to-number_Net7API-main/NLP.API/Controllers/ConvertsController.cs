using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLP.API.Models;
using NLP.API.Services.Abstracts;

namespace NLP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertsController : ControllerBase
    {
        // Dependency Injection
        private readonly ITextConversionService _textConversionService;
        public ConvertsController(ITextConversionService textConversionService) // constructor method
        {
            _textConversionService = textConversionService;
        }

        [HttpPost]
        public IActionResult ConvertText([FromBody] TextConversionRequest request)
        {
            try
            {
                string convertedText = _textConversionService.ConvertToNumberFormat(request.UserText);
                return Ok(new TextConversionResponse { Output = convertedText });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
