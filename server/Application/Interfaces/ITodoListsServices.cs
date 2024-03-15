using Application.Dtos.TodoGroup;
using Application.Dtos.TodoList;
using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ITodoListsServices : IService<TodoList, TodoListDTO, TodoListViewModel> {
        Task<TodoListViewModel> GetDuplicate ( TodoListDTO dto );
    }
}
