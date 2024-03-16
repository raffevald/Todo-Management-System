using Application.Helpers;
using WebApp.ServiceInterfaces;

namespace WebApp.Services
{
    public class HttpClientService : IHttpClientService {
        private readonly HttpClient _httpClient;

        public HttpClientService(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient( "WebApiClient" );
        }



        private async Task<bool> AddAuthHeader ( ) {
            throw new NotImplementedException ();
        }

        #region HttpVerbs
        public async Task<ApiResnpose> Get ( string url, bool addAuthHeader ) {
            if ( addAuthHeader == false ) {
                return await GetResnpose ( url );
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true
                ? await GetResnpose ( url )
                : ApiResnposeBuilder.GenerateUnauthorized ( "Unauthorized", "Please login" ); 
        }
        #endregion

        #region Response Getters
        private async Task<ApiResnpose> GetResnpose( string url  ) {
            var httpResponseMessage = await _httpClient.GetAsync( url );
            
            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResnpose> ();
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }
        #endregion

        public void Dispose ( ) {
            _httpClient?.Dispose ();
        }
    }
}
