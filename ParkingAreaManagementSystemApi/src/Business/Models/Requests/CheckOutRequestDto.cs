using FluentValidation;

namespace Business.Models.Requests;

public record CheckOutRequestDto
{
    public string PlateNumber { get; set; } = default!;
}

public class CheckOutRequestValidator : AbstractValidator<CheckOutRequestDto>
{
    public CheckOutRequestValidator()
    {
        RuleFor(x => x.PlateNumber)
            .NotEmpty()
            .WithMessage("The plate number is required. Please enter a valid plate number.")
            .Matches(@"^[A-Z0-9]{1,7}$")
            .WithMessage("The plate number must contain only uppercase letters and numbers, and be between 1 to 7 characters long.");
    }
}