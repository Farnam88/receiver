namespace AzurePractice.RequestReceiver.Services;

public class ServiceInfo : IServiceInfo
{
    private readonly HttpContext _httpContext;

    public ServiceInfo(IHttpContextAccessor httpContextAccessor)
    {
        _httpContext = httpContextAccessor.HttpContext;
    }

    public ServiceDetail getSetServiceDetail()
    {
        ServiceDetail serviceDetail = new()
        {
            ServiceName = "Receiver",
            Version = "1.0.0"
        };
        var hostName = $"{_httpContext.Request.Scheme}://{_httpContext.Request.Host}";
        serviceDetail.HostName = hostName;
        return serviceDetail;
    }
}