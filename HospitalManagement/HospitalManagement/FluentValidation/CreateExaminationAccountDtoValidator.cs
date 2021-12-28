using FluentValidation;
using HospitalManagement.Dto;

namespace HospitalManagement.FluentValidation
{
    public class CreateExaminationDtoValidator : AbstractValidator<CreateExaminationDto>
    {
        public CreateExaminationDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.ExamineCode).NotEmpty();
        }
    }
}
