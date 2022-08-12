namespace RetoBCP.Application.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }

        public bool IsAuthorized { get; set; }

        public bool IsAllowedToAccess { get; set; }

        public T? Value { get; set; }
        public string? Error { get; set; }

        public static Result<T> Success(T value) => new Result<T> { IsSuccess = true, IsAuthorized = true, IsAllowedToAccess = true, Value = value };

        public static Result<T> Failure(string error) => new Result<T> { IsSuccess = false, IsAuthorized = true, IsAllowedToAccess = true, Error = error };

        public static Result<T> Unauthorized(string error = null) => new Result<T> { IsSuccess = false, IsAuthorized = false, IsAllowedToAccess = false, Error = error };

        public static Result<T> Forbidden(string error = "Usted no cuenta con acceso a este recurso.") => new Result<T> { IsSuccess = false, IsAuthorized = true, IsAllowedToAccess = false, Error = error };


    }
}
