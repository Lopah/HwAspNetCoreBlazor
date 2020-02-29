using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Middleware
{
    public class ValidateHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync( HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("HwAspNetCore-API-KEY"))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        "You must enter a valid HwAspNetCore-API-KEY")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
