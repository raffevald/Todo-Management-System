﻿using Newtonsoft.Json;

namespace Application.Helpers {
    public class ApiResnpose {
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

        public ApiResnpose(
            object data,
            int statusCode,
            string title,
            string message,
            string description
            ) 
        {
            Data = data;
            StatusCode = statusCode;
            Title = title;
            Message = message;
            Description = description;
        }

        public override string ToString ( ) {
            return JsonConvert
                .SerializeObject( this, Formatting.Indented );
        }
    }
}
