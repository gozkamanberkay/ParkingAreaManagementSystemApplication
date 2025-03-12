using FluentValidation;
using Infrastructure.Data.Postgres.Entities;

namespace Business.Models.Requests;

public record CheckInRequestDto
{
    public string PlateNumber { get; set; } = default!;
    public AllowedVehicleSizeEnum AllowedVehicleSize { get; set; } = default!;
}

public class CheckInRequestValidator : AbstractValidator<CheckInRequestDto>
{
    public CheckInRequestValidator()
    {
        RuleFor(x => x.PlateNumber)
            .NotEmpty()
            .WithMessage("The plate number is required. Please enter a valid plate number.")
            .Matches(@"^[A-Z0-9]{1,7}$")
            .WithMessage("The plate number must contain only uppercase letters and numbers, and be between 1 to 7 characters long.");

        RuleFor(x => x.AllowedVehicleSize)
            .Must(value => Enum.IsDefined(typeof(AllowedVehicleSizeEnum), value))
            .WithMessage("Invalid vehicle size. Please select a valid option from the available vehicle sizes.");
    }
}