using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
    }
}
