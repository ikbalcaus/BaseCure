using Microsoft.AspNetCore.Mvc;

namespace BaseCureAPI.Helper;

[ApiController]
public abstract class BaseEndpoint<TRequest, TResponse> : ControllerBase
{
    public abstract Task<TResponse> MakeEndpoint(TRequest request, CancellationToken cancellationToken);
}