using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IBaseResult<TData>
    {
        TData Data { get; set; }
        string Error { get; set; }
        bool Success { get; }
        bool Failure { get; }
    }
}
