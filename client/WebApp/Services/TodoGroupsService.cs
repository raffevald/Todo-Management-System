using Application.Dtos.TodoGroup;
using Application.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services {
    public class TodoGroupsService : ITodoGroupsService {
        private readonly IHttpClientService _httpClientService;

        public TodoGroupsService (IHttpClientService httpClientService) {
            _httpClientService = httpClientService;
        }


        public async Task<ApiResnpose> Get ( ) {
            return await _httpClientService
                .Get ( "TodoGroups/Get", false);
        }

        public async Task<ApiResnpose> Get ( int id ) {
            return await _httpClientService
                .Get ( "TodoGroups/Get", false, id );
        }

        public async Task<ApiResnpose> Post ( TodoGroupDTO todoGroupDTO ) {
            return await _httpClientService
                .Post ( "TodoGroups/Create", false, todoGroupDTO );
        }

        public async Task<ApiResnpose> Put ( int id, TodoGroupDTO todoGroupDTO ) {
            return await _httpClientService
                .Put ( "TodoGroups/Update", false, id, todoGroupDTO );
        }

        public async Task<ApiResnpose> Delete ( int id ) {
            return await _httpClientService
                .Delete ( "TodoGroups/Delete", false, id );
        }
    }
}
