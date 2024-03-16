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

        public async Task<ApiResnpose> Get ( string url, bool addAuthHeader, int id ) {
            if ( addAuthHeader == false ) {
                return await GetResnpose ( url, id );
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true
                ? await GetResnpose ( url, id )
                : ApiResnposeBuilder.GenerateUnauthorized ( "Unauthorized", "Please login" );
        }

        public async Task<ApiResnpose> Post ( string url, bool addAuthHeader, object model ) {
            if ( addAuthHeader == false ) {
                return await PostResnpose ( url, model );
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true
                ? await PostResnpose ( url, model )
                : ApiResnposeBuilder.GenerateUnauthorized ( "Unauthorized", "Please login" );
        }

        public async Task<ApiResnpose> Put ( string url, bool addAuthHeader, int id, object model ) {
            if ( addAuthHeader == false ) {
                return await PutResnpose ( url, id, model );
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true
                ? await PutResnpose ( url, id, model )
                : ApiResnposeBuilder.GenerateUnauthorized ( "Unauthorized", "Please login" );
        }

        public async Task<ApiResnpose> Delete ( string url, bool addAuthHeader, int id ) {
            if ( addAuthHeader == false ) {
                return await DeleteResnpose ( url, id );
            }

            bool authHeaderAdded = await AddAuthHeader();
            return authHeaderAdded == true
                ? await DeleteResnpose ( url, id )
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

        private async Task<ApiResnpose> GetResnpose ( string url, int id ) {
            var httpResponseMessage = await _httpClient.GetAsync( $"{url}/{id}" );

            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResnpose> ();
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        private async Task<ApiResnpose> PostResnpose ( string url, object model ) {
            var httpResponseMessage = await _httpClient.PostAsJsonAsync( url, model );

            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResnpose> ();
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        private async Task<ApiResnpose> PutResnpose ( string url, int id, object model ) {
            var httpResponseMessage = await _httpClient.PutAsJsonAsync( $"{url}/{id}", model );

            #pragma warning disable CS8603 // Possível retorno de referência nula.
            return await httpResponseMessage.Content.ReadFromJsonAsync<ApiResnpose> ();
            #pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        private async Task<ApiResnpose> DeleteResnpose ( string url, int id ) {
            var httpResponseMessage = await _httpClient.DeleteAsync( $"{url}/{id}" );

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
