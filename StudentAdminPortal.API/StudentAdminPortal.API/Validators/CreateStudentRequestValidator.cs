using FluentValidation;
using StudentAdminPortal.API.DataModels.DTO;
using StudentAdminPortal.API.Repositories.Interface;

namespace StudentAdminPortal.API.Validators
{
    public class CreateStudentRequestValidator:AbstractValidator<CreateStudentRequestDto>
    {
        public CreateStudentRequestValidator(IStudentRepository studentRepository)
        {
            RuleFor(x=>x.FirstName).NotEmpty();
            RuleFor(x=>x.LastName).NotEmpty();
            RuleFor(x=>x.DateOfBirth).NotEmpty();
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(10000000000);
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender= studentRepository.GetGendersAsync().Result.ToList().FirstOrDefault(x=>x.Id==id);
                if (gender != null)
                    return true;
                return false;
            }).WithMessage("Please select valid Gender");
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x => x.PostalAddress).NotEmpty();
        }
    }
}
