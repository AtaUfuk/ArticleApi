namespace ArticleApi.Common.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool _isSuccess, string _message, int _resultCode):this(_isSuccess)
        {
            Message = _message;
            ResultCode = _resultCode;
        }
        public Result(bool _isSuccess)
        {
            IsSuccess = _isSuccess;
            if(IsSuccess)
            {
                Message = StaticValues.SuccessMessage;
                ResultCode = StaticValues.SuccessCode;
            }
            else
            {
                Message = StaticValues.ErrorMessage;
                ResultCode = StaticValues.ErrorCode;
            }
        }
        public bool IsSuccess { get; }

        public string Message { get; }

        public int ResultCode { get; }
    }
}
