using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShredKernal.Generics
{
    public class ApiResponse<T>
    {
        public string CommandMessage { get; set; }
        public bool IsValidResponse { get; set; }
        public T DataList { get; set; }
        public int TotalCount { get; set; }


        public ApiResponse()
        {
            CommandMessage = "Something Wrong happened , try again later";
            IsValidResponse = default;
            DataList = default;
        }
        public ApiResponse(T data, string message, bool isValidResponse, int totalCount)
        {
            DataList = data;
            CommandMessage = message;
            IsValidResponse = isValidResponse;
            TotalCount = totalCount;
        }
        public ApiResponse(T data, string message, bool isValidResponse)
        {
            DataList = data;
            CommandMessage = message;
            IsValidResponse = isValidResponse;
        }
    }
}
