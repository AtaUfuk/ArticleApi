namespace ArticleApi.Common.Utilities.Results
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
        int ResultCode { get; }
    }
}
