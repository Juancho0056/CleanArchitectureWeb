using AutoMapper;
using CleanArchitecture.Application.Common.Abstracts;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Utils;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CommandsQueries.TodoBasics.Commands.Create
{
    

    public class CreateTodoBasicHandler : CommandRequestHandler<CreateTodoBasicRequest, ICollection<TodoBasicDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private Globals _options;
        private readonly IMapper _mapper;

        public CreateTodoBasicHandler(IApplicationDbContext context,
            IMediator mediator, IOptions<Globals> options, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _options = options.Value;
            _mapper = mapper;
        }

        public override async Task<ICollection<TodoBasicDto>> HandleCommand(CreateTodoBasicRequest request,
            CancellationToken cancellationToken)
        {

            var vm = new List<TodoBasicDto>();

            var item = new TodoBasic() 
            {
                Title = request.Title
                
            };
            _context.TodoBasics.Add(item);

            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.RollbackTransaction();
                _context.DetachAll();
                return await HandleCommand(request, cancellationToken);
            }

            vm.Add(_mapper.Map<TodoBasicDto>(item));

            return vm;
        }
    }
}

