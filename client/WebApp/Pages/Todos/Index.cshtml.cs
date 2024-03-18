using Application.Dtos.Todo;
using Application.Dtos.TodoGroup;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using WebApp.ServiceInterfaces;

namespace WebApp.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly IDataService _dataService;
       // private readonly IToastNotification _toastr;

        public IndexModel ( IDataService dataService ) {
            _dataService = dataService;
           // _toastr = toastr;
        }

        public List<TodoViewModel>? ViewModels { get; set; }

        public async Task<IActionResult> OnGet () {
            var apiResponse = await _dataService.TodosService.Get();
            var message = "Could not get response from API";

            if ( apiResponse != null ) {
                if ( apiResponse.StatusCode == 200 ) {
                    ViewModels = apiResponse.Data != null
                        ? JsonConvert.DeserializeObject<List<TodoViewModel>> ( apiResponse.Data.ToString ()! )
                        : null;
                    message = $"Message: {apiResponse.Message} <br/> Description: {apiResponse.Description}";
                    // _toastr.AddSuccessToastMessage ( message );
                } else {
                    message = $"Title: {apiResponse.Title} <br/> Message: {apiResponse.Message}";
                   // _toastr.AddErrorToastMessage ( message );
                }
            } else {
               // _toastr.AddInfoToastMessage ( message );
            }

            return Page ();
        }

        public async Task<IActionResult> OnGetChangeCompletedOrNot ( int id, bool isCompleted ) {
            var modelDto = new TodoIsCompletedDto
            {
                Id = id,
                Completed = isCompleted,
            };

            var apiResponse = await _dataService.TodosService.ChangeCompletedOrNot( modelDto );
            var message = "Could not get response from API";

            if ( apiResponse != null ) {
                if ( apiResponse.StatusCode == 200 ) {
                    var updateDto = apiResponse.Data != null
                    ? JsonConvert.DeserializeObject<TodoGroupDTO> ( apiResponse.Data.ToString ()! )
                    : null;
                    message = $"Message: {apiResponse.Message} <br/> Description: {apiResponse.Description}";
                } else {
                    message = $"Title: {apiResponse.Title} <br/> Message: {apiResponse.Message}";
                }
            }

            return new JsonResult ( message );
        }
    }
}
