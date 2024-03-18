using Application.Dtos.Todo;
using Application.Dtos.TodoGroup;
using Application.Helpers;
using WebApp.Services;

namespace WebApp.ServiceInterfaces {
    public interface ITodosService : IGenericService<TodoDTO> {
        Task<ApiResnpose> ChangeCompletedOrNot ( TodoIsCompletedDto todoIsCompletedDto );
    }
}
