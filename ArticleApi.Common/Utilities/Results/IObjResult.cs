namespace ArticleApi.Common.Utilities.Results
{
    public interface IObjResult<out T> : IResult
    {
        T Object { get; }
    }
}
