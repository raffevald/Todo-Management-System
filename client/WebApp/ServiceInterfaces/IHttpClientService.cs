using Application.Helpers;

namespace WebApp.ServiceInterfaces
{
    public interface IHttpClientService : IDisposable
    {
        Task<ApiResnpose> Get(string url, bool addAuthHeader);
        //Task<ApiResnpose> Get( string url, bool addAuthHeader, int id );
        //Task<ApiResnpose> Post( string url, bool addAuthHeader, object model );
        //Task<ApiResnpose> Put( string url, bool addAuthHeader, int id, object model );
        //Task<ApiResnpose> Delete( string url, bool addAuthHeader, int id );
    }
}
