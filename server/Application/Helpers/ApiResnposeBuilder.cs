using System.Net;

namespace Application.Helpers {
    public static class ApiResnposeBuilder {
        public static ApiResnpose GenerateOk ( object data, string message, string description ) {
            return new ApiResnpose ( data, ( int ) HttpStatusCode.OK, "OK", message, description );
        }

        public static ApiResnpose GenerateBadRequest ( string message, string description ) {
            return new ApiResnpose ( null, ( int ) HttpStatusCode.BadRequest, "Bad Request", message, description );
        }

        public static ApiResnpose GenerateUnauthorized ( string message, string description ) {
            return new ApiResnpose ( null, ( int ) HttpStatusCode.Unauthorized, "Unauthorized", message, description );
        }

        public static ApiResnpose GenerateForbidden ( string message, string description ) {
            return new ApiResnpose ( null, ( int ) HttpStatusCode.Forbidden, "Forbidden", message, description );
        }

        public static ApiResnpose GenerateNotFound ( string message, string description ) {
            return new ApiResnpose ( null, ( int ) HttpStatusCode.NotFound, "NotFound", message, description );
        }

        public static ApiResnpose GenerateInternalServerError ( object data, string message, string description ) {
            return new ApiResnpose ( data, ( int ) HttpStatusCode.InternalServerError, "Internal Server Error", message, description );
        }
    }
}
