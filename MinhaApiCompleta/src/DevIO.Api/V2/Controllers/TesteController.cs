using DevIO.Api.Controllers;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        private readonly ILogger _logger;
        public TesteController(INotificador notificar, 
                               IUser appUser, 
                               ILogger<TesteController> logger) : base(notificar, appUser)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {
            _logger.LogTrace("log trace");
            _logger.LogDebug("log debug");
            _logger.LogInformation("log Information");
            _logger.LogWarning("log Warning");
            _logger.LogError("log Error");
            _logger.LogCritical("log Critical");

            return "Api em V2";
        }
    }
}
