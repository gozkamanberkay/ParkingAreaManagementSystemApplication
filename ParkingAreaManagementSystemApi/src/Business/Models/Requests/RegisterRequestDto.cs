using FluentValidation;

namespace Business.Models.Requests;

public record RegisterRequestDto
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}

public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required. Please provide a valid email address.")
            .EmailAddress()
            .WithMessage("Invalid email format. Please enter a valid email address (e.g., user@example.com).");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required. Please provide a password.")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Z]")
            .WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]")
            .WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]")
            .WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]")
            .WithMessage("Password must contain at least one special character (e.g., @, #, $, %).");
    }
}