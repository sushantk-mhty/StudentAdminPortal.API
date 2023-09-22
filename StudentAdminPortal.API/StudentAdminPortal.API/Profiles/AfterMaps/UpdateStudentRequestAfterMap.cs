using AutoMapper;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DataModels.DTO;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequestDto, Student>
    {
        public void Process(UpdateStudentRequestDto source, Student destination, ResolutionContext context)
        {
            destination.Address = new Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
