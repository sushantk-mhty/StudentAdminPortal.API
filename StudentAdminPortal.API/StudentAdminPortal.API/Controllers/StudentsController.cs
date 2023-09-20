using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels.DTO;
using StudentAdminPortal.API.Repositories.Interface;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [NonAction]
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await studentRepository.GetStudentsAsync();
            var response = new List<StudentDto>();
            foreach (var student in students)
            {
                response.Add(new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImageUrl = student.ProfileImageUrl,
                    GenderId = student.GenderId,
                    Address = new AddressDto()
                    {
                        Id = student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress = student.Address.PostalAddress
                    },
                    Gender = new GenderDto()
                    {
                        Id = student.Gender.Id,
                        Description = student.Gender.Description
                    }
                });
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetStudentsAsync();
            var response = mapper.Map<List<StudentDto>>(students);
            return Ok(response);
        }
    }
}
