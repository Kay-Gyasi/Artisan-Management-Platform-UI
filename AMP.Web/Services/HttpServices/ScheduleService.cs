namespace AMP.Web.Services.HttpServices;

[Service]
public class ScheduleService
{
    private readonly IHttpRequestBase _http;

    public ScheduleService(IHttpRequestBase http)
    {
        _http = http;
    }

    public async Task<List<ScheduleDto?>> GetAllAsync()
    {
        var orders = await _http.GetRequestAsync<List<ScheduleDto?>>("schedule.json",
            new CancellationToken());
        return orders.Result;
    }
}