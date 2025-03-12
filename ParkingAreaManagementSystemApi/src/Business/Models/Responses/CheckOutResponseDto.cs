namespace Business.Models.Responses;

public record CheckOutResponseDto
{
    public DateTime CheckedInAt { get; set; } = default!;
    public DateTime CheckedOutAt { get; set; } = default!;
    public double HourlyFee { get; set; } = default!;
    public double ParkDurationInHours { get; set; } = default!;
    public double TotalFee { get; set; } = default!;
}