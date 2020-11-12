using AutoMapper;
using CleanArchitecture.Application.Common.Abstracts;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Utils;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CommandsQueries.TodoBasics.Commands.Update
{
    public class UpdateTodoBasicHandler: CommandRequestHandler<UpdateTodoBasicRequest, ICollection<TodoBasicDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private Globals _options;
        private readonly IMapper _mapper;

    public UpdateTodoBasicHandler(IApplicationDbContext context,
        IMediator mediator, IOptions<Globals> options, IMapper mapper) : base(context)
    {
        _context = context;
        _mediator = mediator;
        _options = options.Value;
        _mapper = mapper;
    }

    public override async Task<ICollection<TodoBasicDto>> HandleCommand(UpdateTodoBasicRequest request,
        CancellationToken cancellationToken)
    {

        var vm = new List<TodoBasicDto>();
        var todoBasic = _context.TodoBasics
                    .AsNoTracking()
                    .Where(e => e.Id == request.Id)
                    .FirstOrDefault();
        todoBasic.Title = request.Title;
        _context.TodoBasics.Update(todoBasic);

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

        vm.Add(_mapper.Map<TodoBasicDto>(todoBasic));

        return vm;
    }
}
}

