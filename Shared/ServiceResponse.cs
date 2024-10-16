﻿using System.Text.Json.Serialization;

namespace eCommerceWebApiBackEnd.Shared
{
    public class ServiceResponse<T>
    {        
        public T? Data { get; set; }        
        public bool Success { get; set; } = true;        
        public string Message { get; set; } = string.Empty;
    }
}
