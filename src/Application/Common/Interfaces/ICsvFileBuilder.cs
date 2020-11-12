
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoBasic> records);
    }
}
