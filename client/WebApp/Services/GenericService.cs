using Application.Dtos.TodoGroup;
using Application.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services {
    public class GenericService<TDto> : IGenericService<TDto> where TDto : class {
        private readonly IHttpClientService _httpClientService;
        private readonly string _controllerName;

        public GenericService ( IHttpClientService httpClientService, string controllerName ) {
            _httpClientService = httpClientService;
            _controllerName = controllerName;
        }


        public async Task<ApiResnpose> Get ( ) {
            return await _httpClientService
                .Get ( $"{_controllerName}/Get", false );
        }

        public async Task<ApiResnpose> Get ( int id ) {
            return await _httpClientService
                .Get ( $"{_controllerName}/Get", false, id );
        }

        public async Task<ApiResnpose> Post ( TDto modelDto ) {
            return await _httpClientService
                .Post ( $"{_controllerName}/Create", false, modelDto );
        }

        public async Task<ApiResnpose> Put ( int id, TDto modelDto ) {
            return await _httpClientService
                .Put ( $"{_controllerName}/Update", false, id, modelDto );
        }

        public async Task<ApiResnpose> Delete ( int id ) {
            return await _httpClientService
                .Delete ( $"{_controllerName}/Delete", false, id );
        }
    }
}
