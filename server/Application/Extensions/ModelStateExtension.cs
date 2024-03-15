using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Extensions {
    public static class ModelStateExtension {
        public static List<string> GetModelStateErros( this ModelStateDictionary dictionary) {
            var erros = dictionary
                .SelectMany( x => x.Value?.Errors )
                .Select( x => x.ErrorMessage)
                .ToList() ;
            
            return erros ;
        }
    }
}
