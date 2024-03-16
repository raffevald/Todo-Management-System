using WebApp.ServiceInterfaces;

namespace WebApp.Services {
    public class DataService : IDataService {

        public ITodoGroupsService TodoGroupsService { get; }


        private readonly IHttpClientService _httpClientService;

        public DataService ( IHttpClientService httpClientService ) {
            _httpClientService = httpClientService;

            TodoGroupsService = new TodoGroupsService(_httpClientService);
        }

    }
}
