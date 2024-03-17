using Application.Dtos.TodoGroup;
using Application.Helpers;
using Application.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<IActionResult> OnGet() {
        var apiResponse = await _dataService.TodoGroupsService.Get();
        var message = "Could not get response from API";

        if ( apiResponse != null ) {
            if ( apiResponse.StatusCode == 200) {
                ViewModels = apiResponse.Data != null
                    ? JsonConvert.DeserializeObject<List<TodoGroupViewModel>> ( apiResponse.Data.ToString ()! )
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

    public async Task<IActionResult> OnGetAddNew ( string groupName ) {
        var modelDto = new TodoGroupDTO { 
            GroupName = groupName,
            CreateOn = DateTime.Now
        };

        var apiResponse = await _dataService.TodoGroupsService.Post( modelDto );
        var message = "Could not get response from API";

        if ( apiResponse != null ) {
            if ( apiResponse.StatusCode == 200 ) {
                var createDto = apiResponse.Data != null
                    ? JsonConvert.DeserializeObject<TodoGroupDTO> ( apiResponse.Data.ToString ()! )
                    : null;
                message = $"Message: {apiResponse.Message} <br/> Description: {apiResponse.Description}";
            } else {
                message = $"Title: {apiResponse.Title} <br/> Message: {apiResponse.Message}";
            }
        }

        return new JsonResult(message);
    }

    public async Task<IActionResult> OnGetAddUpdate ( int id, string groupName ) {
        var modelDto = new TodoGroupDTO
        {
            Id = id,
            GroupName = groupName,
        };

        var apiResponse = await _dataService.TodoGroupsService.Put( id, modelDto );
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

    public async Task<IActionResult> OnGetDelete ( int id ) {
        var apiResponse = await _dataService.TodoGroupsService.Delete( id );
        var message = "Could not get response from API";

        if ( apiResponse != null ) {
            if ( apiResponse.StatusCode == 200 ) {
                var rwosAfected = apiResponse.Data != null
                    ? JsonConvert.DeserializeObject<ApiResnpose> ( apiResponse.ToString ()! )
                    : null;
                message = $"Message: {apiResponse.Message} <br/> Description: {apiResponse.Description}";
            } else {
                message = $"Title: {apiResponse.Title} <br/> Message: {apiResponse.Message}";
            }
        }

        return new JsonResult ( message );
    }
}
