

namespace Homework2.Application.Responses
{
    public class ApiResponses<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public int StatusCode { get; set; }

        // Método estático para respuestas de éxito
        public static ApiResponses<T> SuccessResponse(T data, string message = "Operación exitosa", int statusCode = 200)
        {
            return new ApiResponses<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = statusCode
            };
        }

        // Método estático para respuestas de error
        public static ApiResponses<T> ErrorResponse(string message, int statusCode = 400)
        {
            return new ApiResponses<T>
            {
                Success = false,
                Message = message,
                Data = null,
                StatusCode = statusCode
            };
        }
    }
}
