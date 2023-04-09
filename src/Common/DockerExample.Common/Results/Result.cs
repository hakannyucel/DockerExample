namespace DockerExample.Common.Results
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public Result()
        {

        }

        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    public class Result<T> : IResult<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }

        public Result()
        {
        }

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public Result(bool isSuccess, string message, T data)
        {
            Message = message;
            IsSuccess = isSuccess;
            Data = data;
        }
    }
}
