namespace MongoDbIntegration.Models
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { Status = true, Message = "Operation successful.", Data = new List<T> { data } };
        }

        public static ApiResponse<T> Success(List<T> dataList)
        {
            return new ApiResponse<T> { Status = true, Message = "Operation successful.", Data = dataList };
        }

        public static ApiResponse<T> NotFound()
        {
            return new ApiResponse<T> { Status = false, Message = "Object not found.", Data = null };
        }

        public static ApiResponse<T> Error(string errorMessage)
        {
            return new ApiResponse<T> { Status = false, Message = errorMessage, Data = null };
        }
    }
}
