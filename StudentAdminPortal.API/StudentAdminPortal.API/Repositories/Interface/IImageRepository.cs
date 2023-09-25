namespace StudentAdminPortal.API.Repositories.Interface
{
    public interface IImageRepository
    {
       Task<string> UploadAsync(IFormFile file,string fileName);
    }
}
