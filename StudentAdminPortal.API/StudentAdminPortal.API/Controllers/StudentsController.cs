using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels;
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
            var response = mapper.Map<IEnumerable<StudentDto>>(students);
            return Ok(response);
        }


        [HttpGet]
        [Route("{studentId:Guid}"),ActionName("GetStudentByIdAsync")]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] Guid studentId)
        {
            //Featch Student Details
            var student = await studentRepository.GetStudentByIdAsync(studentId);

            //Return Student
            if (student is null)
                return NotFound();

            return Ok(mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequestDto request)
        {
          var student=  await studentRepository.CreateStudent(mapper.Map<Student>(request));
            return CreatedAtAction(nameof(GetStudentByIdAsync), new { studentId = student.Id }, mapper.Map<StudentDto>(student));

        }

        [HttpPut]
        [Route("{studentId:Guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid studentId, [FromBody] UpdateStudentRequestDto request)
        {
            if (await studentRepository.Exists(studentId))
            {

                //update details
                var updatedStudent = await studentRepository.UpdateStudentAsync(studentId, mapper.Map<Student>(request));
                if (updatedStudent is not null)
                    return Ok(mapper.Map<StudentDto>(updatedStudent));
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{studentId:Guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid studentId)
        {
            if (await studentRepository.Exists(studentId))
            {
              var student= await studentRepository.DeleteStudentAsync(studentId);
              return Ok(mapper.Map<StudentDto>(student));
            }
            return NotFound();
        }

    }
}
