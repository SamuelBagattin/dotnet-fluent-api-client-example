using System.Threading;
using System.Threading.Tasks;

namespace FluentApiClientExample.Requests
{
    public interface IAsyncRequest<T>
    {
        public Task<T> Execute(CancellationToken cancellationToken = default);
    }

}