using CleanArchitecture.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Common.Results
{
    public class QueryResult<TData> : IBaseResult<TData>
    {
        public TData Data { get; set; }
        public string Error { get; set; }
        public bool Success => this.Data != null;
        public bool Failure => this.Error != null;

        protected QueryResult() { }
        protected QueryResult(TData data)
        {
            this.Data = data;
        }
        protected QueryResult(string error)
        {
            this.Error = error;
        }

        public static QueryResult<TData> Ok() => new QueryResult<TData>();
        public static QueryResult<TData> Ok(TData data) => new QueryResult<TData>(data);
        public static QueryResult<TData> Fail(string error) => new QueryResult<TData>(error);
    }
}

