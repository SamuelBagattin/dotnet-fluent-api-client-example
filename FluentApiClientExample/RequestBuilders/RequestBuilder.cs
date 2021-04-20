namespace FluentApiClientExample.RequestBuilders
{
    public abstract class RequestBuilder<T>
    {
        internal abstract T Build();
    }

}