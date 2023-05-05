using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientFactoryPractice.Services.Abstractions
{
    public interface IInternalHTTPClientService
    {
        Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null)
       where TRequest : class;
    }
}
