using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Erros;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]
public class ExceptionModel : PageModel
{
    public IActionResult OnGet( int? statusCode = null )
    {
        switch ( statusCode ) {
            case 404:
                return RedirectToPage ( "/Erros/NotFound" );
            case 500:
                return RedirectToPage ( "/Erros/InternalServerError" );
            default:
                return Page ();
        }
    }
}
