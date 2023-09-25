using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(Guid studentId);
        Task<IEnumerable<Gender>> GetGendersAsync();
        Task<bool> Exists(Guid studentId);
        Task<Student?> UpdateStudentAsync(Guid studentId,Student student);
        Task<Student> DeleteStudentAsync(Guid studentId);
        Task<Student> CreateStudent(Student student);
        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);
    }
}
