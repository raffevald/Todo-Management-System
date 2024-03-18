using Application.Dtos.Todo;
using Application.Dtos.TodoGroup;
using Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using WebApp.ServiceInterfaces;

namespace WebApp.Services {
    public class TodosService : GenericService<TodoDTO>, ITodosService {
        private readonly IHttpClientService _httpClientService;
        private const string controllerName = "Todos";

        public TodosService ( IHttpClientService httpClientService ) : base ( httpClientService , controllerName ) {
            _httpClientService = httpClientService;
        }

        public async Task<ApiResnpose> ChangeCompletedOrNot ( TodoIsCompletedDto todoIsCompletedDto ) {
            return await _httpClientService
                .Post ( "Todos/ChangeCompletedOrNot", false, todoIsCompletedDto );
        }
    }
}
