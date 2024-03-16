using Application.Dtos.TodoGroup;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NToastNotify;
using WebApp.ServiceInterfaces;

namespace WebApp.Pages.TodoGroups;

public class IndexModel : PageModel
{
    private readonly IDataService _dataService;
    private readonly IToastNotification _toastr;

    public IndexModel( IDataService dataService, IToastNotification toastr ) {
         _dataService = dataService;
        _toastr = toastr;
    }

    public List<TodoGroupViewModel>? ViewModels { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var apiResponse = await _dataService.TodoGroupsService.Get();
        var message = "Could not get response from API";

        if ( apiResponse != null ) {
            if ( apiResponse.StatusCode == 200) {
                ViewModels = apiResponse.Data != null
                    ? JsonConvert.DeserializeObject<List<TodoGroupViewModel>> ( apiResponse.Data.ToString () )
                    : null;
                message = $"Message: {apiResponse.Message} <br/> Description: {apiResponse.Description}";
                _toastr.AddSuccessToastMessage ( message );
            } else {
                message = $"Title: {apiResponse.Title} <br/> Message: { apiResponse.Message }";
                _toastr.AddErrorToastMessage( message );
            }
        } else {
            _toastr.AddInfoToastMessage(message);
        }

        return Page ();
    }
}
