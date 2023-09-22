using AutoMapper;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.DataModels.DTO;
using StudentAdminPortal.API.Profiles.AfterMaps;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<UpdateStudentRequestDto, Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();
            CreateMap<CreateStudentRequestDto, Student>()
                .AfterMap<CreateStudentRequestAfterMap>();

            //.ForMember(dest => dest.Address.PhysicalAddress, opt => opt.MapFrom(src => src.PhysicalAddress))
            //.ForMember(dest => dest.Address.PostalAddress, opt => opt.MapFrom(src => src.PostalAddress));

        }
    }
}
