using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MediatR;

namespace SomeApplication.Controllers
{
    public abstract class BaseController : ApiController
    {
        private readonly IMediator mediator;

        protected BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IHttpActionResult> Handle<TRequest>(TRequest request, Func<IHttpActionResult> func) 
            where TRequest : IRequest
        {
            return await TryHandle(async () =>
            {
                await mediator.Send(request);

                return func.Invoke();
            });
        }

        protected async Task<IHttpActionResult> Handle<TRequest, TResponse>(TRequest request, Func<TResponse, IHttpActionResult> func) 
            where TRequest : IRequest<TResponse>
        {
            return await TryHandle(async () =>
            {
                var result = await mediator.Send(request);

                return func.Invoke(result);
            });
        }

        private async Task<IHttpActionResult> TryHandle(Func<Task<IHttpActionResult>> func)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return await func.Invoke();

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}