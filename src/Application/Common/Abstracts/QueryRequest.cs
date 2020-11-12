using CleanArchitecture.Application.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Common.Abstracts
{
    public abstract class QueryRequest<TData> : IRequest<QueryResult<TData>>
    {
    }
}