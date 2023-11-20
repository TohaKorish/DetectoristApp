using DetectoristApp.BLL.DTO.Request;
using FluentValidation;

namespace DetectoristApp.BLL.Validation;

public class MetaldetectorRequestValidator : AbstractValidator<MetaldetectorRequestDTO>
{
    public MetaldetectorRequestValidator()
    {
        RuleFor(dto => dto.Brand)
            .NotEmpty()
            .WithMessage("Brand is required");

        RuleFor(dto => dto.Model)
            .NotEmpty()
            .WithMessage("Model is required");

        RuleFor(dto => dto.Weight)
            .NotEmpty()
            .GreaterThan(0.2)
            .LessThanOrEqualTo(20)
            .WithMessage("Weight must be greater than 0.2 and lower than or equal to 20");
        
        RuleFor(dto => dto.IsWaterproof)
            .NotEmpty()
            .WithMessage("Waterproof is required");
        
        RuleFor(dto => dto.CoilId)
            .NotNull()
            .WithMessage("CoilId is required")
            .GreaterThan(0)
            .WithMessage("CoilId must be greater than 0");
    }
}