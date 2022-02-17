using GCP.CloudStorage.Api.ExternalServices.Models;

namespace GCP.CloudStorage.Api.ExternalServices
{
    public interface IFileStorage
    {
        Task UploadFileAsync(string bucket, string fileName, string contentType, Stream fileStream);
        Task<FileStorageInfo?> GetFileInfoAsync(string bucket, string fileName);
        Task DownloadObjectAsync(string bucket, string fileName, Stream destination);
    }
}