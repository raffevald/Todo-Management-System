using Application.Dtos.Todo;
using Application.Dtos.TodoGroup;
using Application.Dtos.TodoList;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;

namespace Application.Mappings
{
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            CreateMap<TodoGroupDTO, TodoGroup> ();
            CreateMap<TodoGroup, TodoGroupDTO> ();
            CreateMap<TodoGroup, TodoGroupViewModel> ();

            CreateMap<TodoListDTO, TodoList> ();
            CreateMap<TodoList, TodoListDTO> ();
            CreateMap<TodoList, TodoListViewModel> ();

            CreateMap<TodoDTO, Todo> ();
            CreateMap<Todo, TodoDTO> ();
            CreateMap<Todo, TodoViewModel> ();
        }
    }
}
