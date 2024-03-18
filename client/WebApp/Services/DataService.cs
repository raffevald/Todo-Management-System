using WebApp.ServiceInterfaces;

namespace WebApp.Services {
    public class DataService : IDataService {

        public ITodoGroupsService TodoGroupsService { get; }
        public ITodosService TodosService { get; }


        private readonly IHttpClientService _httpClientService;

        public DataService ( IHttpClientService httpClientService ) {
            _httpClientService = httpClientService;

            TodoGroupsService = new TodoGroupsService(_httpClientService);
            TodosService = new TodosService ( _httpClientService );
        }
    }
}
