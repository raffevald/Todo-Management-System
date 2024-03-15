using Application.Dtos.TodoGroup;
using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ITodoGroupsServices : IService<TodoGroup, TodoGroupDTO, TodoGroupViewModel> {
        Task<TodoGroupViewModel> GetDuplicate ( TodoGroupDTO dto );
    }
}
