using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.CommandsQueries.TodoBasics
{
    public class TodoBasicDto : IMapFrom<TodoBasic>
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoBasic, TodoBasicDto>();
        }

    }
}
