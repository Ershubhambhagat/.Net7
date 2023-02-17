﻿namespace Net7.Models
{
    public class ServiceResponce<T>
    {

        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

    }
}
