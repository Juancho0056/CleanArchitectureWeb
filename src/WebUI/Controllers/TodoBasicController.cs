using CleanArchitecture.Application.CommandsQueries.TodoBasics;
using CleanArchitecture.Application.CommandsQueries.TodoBasics.Commands.Create;
using CleanArchitecture.Application.CommandsQueries.TodoBasics.Commands.Delete;
using CleanArchitecture.Application.CommandsQueries.TodoBasics.Commands.Update;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    /// <summary>
    /// Controlador de acciones api/TodoBasicController
    /// </summary>
    public class TodoBasicController : ApiController
    {
        /// <summary>
        /// Add TodoBasic
        /// </summary>
        /// <summary>
        /// Add TodoBasic
        /// </summary>
        /// <remarks>
        /// Create new record for TodoBasic
        /// </remarks>
        /// <param name="command">Instance for CreateTodoBasicRequest</param>
        /// <returns></returns>
        // POST: api/TodoBasic/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateTodoBasicRequest command)
        {
            return await base.Command<CreateTodoBasicRequest, ICollection<TodoBasicDto>>(command);
        }
        /// <summary>
        /// Update TodoBasic
        /// </summary>
        /// <remarks>
        /// Update a specific record for TodoBasic
        /// </remarks>
        /// <param name="command">Instance for UpdateTodoBasicRequest</param>
        /// <returns></returns>
        // POST: api/TodoBasic/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateTodoBasicRequest command)
        {
            return await base.Command<UpdateTodoBasicRequest, ICollection<TodoBasicDto>>(command);
        }
        ///// <summary>
        ///// Delete TodoBasic
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for TodoBasic
        ///// </remarks>
        ///// <param name="command">Instance for DeleteTodoBasicRequest</param>
        ///// <returns></returns>
        //// POST: api/TodoBasic/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteTodoBasicRequest command)
        {
            return await base.Command<DeleteTodoBasicRequest, ICollection<TodoBasicDto>>(command);
        }

        // GET: odata/TodoBasic

        [HttpGet("[action]")]
        [EnableQuery(MaxExpansionDepth = 50)]
        public IQueryable<TodoBasic> GetAll()
        {
            return _context.TodoBasics;
        }

        // GET: get/TodoBasic/5
        [HttpGet("[action]")]
        [EnableQuery(MaxExpansionDepth = 50)]
        public SingleResult<TodoBasic> Get([FromODataUri] int key)
        {
            IQueryable<TodoBasic> result = _context.TodoBasics.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }
    }
}
