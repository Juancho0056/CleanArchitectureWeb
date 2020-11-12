using CleanArchitecture.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Common.Results
{
    public class CommandResult<TData> : IBaseResult<TData>
    {
        public TData Data { get; set; }
        public string Error { get; set; }
        public bool Success => this.Error == null;
        public bool Failure => this.Error != null;

        protected CommandResult() { }

        protected CommandResult(TData data)
        {
            this.Data = data;
        }

        protected CommandResult(string error)
        {
            this.Error = error;
        }

        public static CommandResult<TData> Ok() => new CommandResult<TData>();
        public static CommandResult<TData> Ok(TData data) => new CommandResult<TData>(data);
        public static CommandResult<TData> Fail(string error) => new CommandResult<TData>(error);
    }
}
