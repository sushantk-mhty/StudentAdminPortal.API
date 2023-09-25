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
        public async Task<Student> GetStudentByIdAsync(Guid studentId)
        {
            return await dbContext.Student
                       .Include(nameof(Gender)).Include(nameof(Address))
                       .FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            return await dbContext.Gender.ToListAsync();
        }

        public async Task<bool> Exists(Guid studentId)
        {
            await dbContext.Student.AnyAsync(x => x.Id == studentId);
            return true;
        }

        public async Task<Student?> UpdateStudentAsync(Guid studentId, Student student)
        {
            var existingStudent = await GetStudentByIdAsync(studentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Email = student.Email;
                existingStudent.DateOfBirth = student.DateOfBirth;
                existingStudent.GenderId = student.GenderId;
                existingStudent.Mobile = student.Mobile;
                existingStudent.Address.PhysicalAddress = student.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = student.Address.PostalAddress;

                await dbContext.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<Student> DeleteStudentAsync(Guid studentId)
        {
            var student = await GetStudentByIdAsync(studentId);
            if (student is not null)
            {
                dbContext.Student.Remove(student);
                await dbContext.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await dbContext.Student.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student= await GetStudentByIdAsync(studentId);
            if (student is not null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
