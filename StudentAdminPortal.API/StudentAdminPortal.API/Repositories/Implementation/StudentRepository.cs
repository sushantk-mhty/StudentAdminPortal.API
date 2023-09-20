using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories.Interface;

namespace StudentAdminPortal.API.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext dbContext;
        public StudentRepository(StudentAdminContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
           return await dbContext.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
