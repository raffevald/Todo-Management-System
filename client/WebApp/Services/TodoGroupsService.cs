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
    }
}
