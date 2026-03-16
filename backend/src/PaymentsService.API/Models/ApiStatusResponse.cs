namespace PaymentsService.Api.Models;

public class ApiStatusResponse
{
    public string Service { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public string Environment { get; set; } = string.Empty;

    public DateTime Timestamp { get; set; }
}