using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DevIO.Business.Interfaces;
using DevIO.Business.Notifications;

namespace DevIO.Api.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificador _notificar;

        protected MainController(INotificador notificar)
        {
            _notificar = notificar;
        }

        protected bool OperacaoValida()
        {
            return !_notificar.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                data = _notificar.ObterNotificacao().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModeInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErroModeInvalida(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in errors)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificar.Handler(new Notificacao(mensagem));
        }
    }
}
