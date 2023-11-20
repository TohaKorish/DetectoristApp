using DetectoristApp.BLL.DTO.Request;
using FluentValidation;

namespace DetectoristApp.BLL.Validation;

public class CoilRequestValidator : AbstractValidator<CoilRequestDTO>
{
    public CoilRequestValidator()
    {
        RuleFor(dto => dto.Brand)
            .NotEmpty()
            .WithMessage("Brand is required");

        RuleFor(dto => dto.Model)
            .NotEmpty()
            .WithMessage("Model is required");

        RuleFor(dto => dto.Diameter)
            .NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(40)
            .WithMessage("Diameter must be greater than 0 and lower than or equal to 40");
    }
}