using DetectoristApp.BLL.DTO.Request;
using FluentValidation;

namespace DetectoristApp.BLL.Validation;

public class DetectoristRequestValidator : AbstractValidator<DetectoristRequestDTO>
{
    public DetectoristRequestValidator()
    {
        RuleFor(dto => dto.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .MaximumLength(45)
            .WithMessage("Username must not exceed 45 characters");

        RuleFor(dto => dto.Age)
            .NotEmpty()
            .WithMessage("Age is required")
            .InclusiveBetween(14, 99)
            .WithMessage("Age must be between 14 and 99");

        RuleFor(dto => dto.Sex)
            .NotEmpty()
            .WithMessage("Sex is required");

        RuleFor(dto => dto.MetaldetectorId)
            .NotNull()
            .WithMessage("MetaldetectorId is required")
            .GreaterThan(0)
            .WithMessage("MetaldetectorId must be greater than 0");
    }
}
