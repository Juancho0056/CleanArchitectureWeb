using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;
        private IConfiguration _configuration;
        private IWebHostEnvironment _environment;
        private IApplicationDbContext context;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IApplicationDbContext _context => context ??= HttpContext.RequestServices.GetService<IApplicationDbContext>();
        protected IConfiguration Configuration => _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();
        protected IWebHostEnvironment _env => _environment ??= HttpContext.RequestServices.GetService<IWebHostEnvironment>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Request"></typeparam>
        /// <typeparam name="Response"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual async Task<ActionResult> Command<Request, Response>(Request command) where Request : IRequest<CommandResult<Response>>
        {
            //TryValidateModel(command);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await Mediator.Send(command);
                if (result.Success) return Ok(result.Data);

                return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
            }
            catch (System.Exception e)
            {

                throw e;
            }
            

          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Request"></typeparam>
        /// <typeparam name="Response"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual async Task<ActionResult> Query<Request, Response>(Request command) where Request : IRequest<QueryResult<Response>>
        {
            TryValidateModel(command);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await Mediator.Send(command);

            if (result.Success) return Ok(result.Data);

            if (result.Failure) return StatusCode(StatusCodes.Status500InternalServerError, result.Error);

            return NoContent();
        }

    }
}