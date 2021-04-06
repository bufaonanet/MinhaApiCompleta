using DevIO.Api.Controllers;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.V1.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        public TesteController(INotificador notificar, IUser appUser) : base(notificar, appUser)
        {
        }

        [HttpGet]
        public string Valor()
        {
            return "Api em V1";
        }
    }
}
