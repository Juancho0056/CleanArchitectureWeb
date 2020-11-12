using CleanArchitecture.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Abstracts
{
    public abstract class QueryRequestHandler<TRequest, TData> : IRequestHandler<TRequest, QueryResult<TData>> where TRequest : IRequest<QueryResult<TData>>
    {
        public virtual async Task<QueryResult<TData>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                TData vm = await HandleQuery(request, cancellationToken);

                if (vm is null) return QueryResult<TData>.Ok();

                return QueryResult<TData>.Ok(vm);
            }
            catch (Exception e)
            {
                return QueryResult<TData>.Fail(e.Message);
            }
        }

        public abstract Task<TData> HandleQuery(TRequest request, CancellationToken cancellationToken);
    }
}