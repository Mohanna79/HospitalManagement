using FluentValidation;
using HospitalManagement.Dto;

namespace HospitalManagement.FluentValidation
{
    public class CreateDoctorDtoValidator : AbstractValidator<CreateDoctorDto>
    {
        public CreateDoctorDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.MedicalSystemCode).GreaterThanOrEqualTo(1000).LessThanOrEqualTo(9999).WithMessage("کد نظام پزشکی باید 4 رقمی باشد");
        }
    }
}
