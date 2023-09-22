using AutoMapper;
using StudentAdminPortal.API.DataModels.DTO;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class CreateStudentRequestAfterMap : IMappingAction<CreateStudentRequestDto, Student>
    {
        public void Process(CreateStudentRequestDto source, Student destination, ResolutionContext context)
        {
            destination.Id=Guid.NewGuid();
            destination.Address = new Address()
            {
                Id=Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
