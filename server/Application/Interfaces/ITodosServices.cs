using Application.Dtos.Todo;
using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces {
    public interface ITodosServices : IService<Todo, TodoDTO, TodoViewModel> {
        Task<TodoViewModel> GetDuplicate ( TodoDTO dto );
    }
}