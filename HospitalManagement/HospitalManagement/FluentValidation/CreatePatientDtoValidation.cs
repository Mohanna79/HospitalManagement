using FluentValidation;
using HospitalManagement.Dto;

namespace HospitalManagement.FluentValidation
{
    public class CreatePatientDtoValidation : AbstractValidator<CreatePatientDto>
    {
        public CreatePatientDtoValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("اسم را وارد کنید.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("نام خانوادگی را وارد کنید.");
            RuleFor(p => p.NationalCode).NotEmpty().WithMessage("کد ملی را وارد کنید.");
            RuleFor(p => p.LastName).MinimumLength(5).WithMessage("نام خانوادگی حداقل 5 کاراکتر باشد.");
            RuleFor(p => p.NationalCode).Length(10).WithMessage("کد ملی باید 10 رقمی باشد.");

        }
    }


}
