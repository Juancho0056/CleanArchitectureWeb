using CleanArchitecture.Application.Common.Abstracts;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Application.CommandsQueries.TodoBasics.Commands.Create
{
    public partial class CreateTodoBasicRequest : CommandRequest<ICollection<TodoBasicDto>>, IValidatableObject
    {
        public string Title { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();

            var serviceOptions = (IOptions<Globals>)validationContext.GetService(typeof(IOptions<Globals>));
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                #region TodoBasics
                var todoBasic = _context.TodoBasics
                    .AsNoTracking()
                    .Where(e => e.Title == "")
                    .FirstOrDefault();

                if (!(todoBasic is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "TodoBasic" }));
                    return errores;
                }
                #endregion

                return errores;
            }
            catch (Exception e)
            {
                errores.Add(new ValidationResult(e.Message));
                return errores;
            }
        }
    }
}
