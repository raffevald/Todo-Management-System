using Application.Helpers;

namespace WebApp.ServiceInterfaces {
    public interface IGenericService<TDto> where TDto : class {
        Task<ApiResnpose> Get ( );
        Task<ApiResnpose> Get ( int id );
        Task<ApiResnpose> Post ( TDto modelDto );
        Task<ApiResnpose> Put ( int id, TDto modelDto );
        Task<ApiResnpose> Delete ( int id );
    }
}
