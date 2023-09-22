using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DataModels.DTO;
using StudentAdminPortal.API.Repositories.Interface;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public GendersController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders =await studentRepository.GetGendersAsync();
            if (genders is null || !genders.Any())
                return NotFound();
            return Ok(mapper.Map<IEnumerable<GenderDto>>(genders));
        }

    }
}
