
using System;
using System.Collections.Generic;

namespace Account.Web.Api.Result
{
    public class Result<T>
    {
        public List<T> Items { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public Result()
        {
            Message = "Ok";
            Success = true;
            Items = new List<T>();
        }

        public void SetException(Exception ex)
        {
            Message = ex.Message;
            Success = false;
        }
    }
}
