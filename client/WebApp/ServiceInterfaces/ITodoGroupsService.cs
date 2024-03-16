using Application.Dtos.TodoGroup;
using Application.Helpers;

namespace WebApp.ServiceInterfaces {
    public interface ITodoGroupsService {
        Task<ApiResnpose> Get ();
        Task<ApiResnpose> Get ( int id );
        Task<ApiResnpose> Post ( TodoGroupDTO todoGroupDTO );
        Task<ApiResnpose> Put ( int id, TodoGroupDTO todoGroupDTO );
        Task<ApiResnpose> Delete ( int id );
    }
}
