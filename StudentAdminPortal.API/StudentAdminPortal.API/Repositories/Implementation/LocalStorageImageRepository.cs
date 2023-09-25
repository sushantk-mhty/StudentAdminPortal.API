using StudentAdminPortal.API.DataModels;
using StudentAdminPortal.API.Repositories.Interface;

namespace StudentAdminPortal.API.Repositories.Implementation
{
    public class LocalStorageImageRepository : IImageRepository
    {
        private readonly StudentAdminContext dbContext;
        public LocalStorageImageRepository(StudentAdminContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<string> UploadAsync(IFormFile file, string fileName)
        {
            var filePath=Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images",fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
           await file.CopyToAsync(fileStream);
            return GetServerRelativePath(fileName);
        }
        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
