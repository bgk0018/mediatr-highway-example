using System;
using System.Threading.Tasks;
using Business.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Accounts.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IMediator mediator;

        protected BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> Handle<TRequest>(TRequest request, Func<IActionResult> func)
            where TRequest : IRequest
        {
            return await TryHandle(async () =>
            {
                await mediator.Send(request);

                return func.Invoke();
            });
        }

        protected async Task<IActionResult> Handle<TRequest, TResponse>(TRequest request,
            Func<TResponse, IActionResult> func)
            where TRequest : IRequest<TResponse>
        {
            return await TryHandle(async () =>
            {
                var result = await mediator.Send(request);

                return func.Invoke(result);
            });
        }

        private async Task<IActionResult> TryHandle(Func<Task<IActionResult>> func)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return await func.Invoke();
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                //Production shouldn't give full exception dump, not sure how to do this in Core yet
                return StatusCode(500, e);
            }
        }
    }
}