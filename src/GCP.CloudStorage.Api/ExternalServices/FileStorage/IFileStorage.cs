using GCP.CloudStorage.Api.ExternalServices.FileStorage.Models;

namespace GCP.CloudStorage.Api.ExternalServices.FileStorage;

public interface IFileStorage
{
    Task UploadFileAsync(string bucket, string fileName, string contentType, Stream fileStream);
    Task<FileStorageInfo?> GetFileInfoAsync(string bucket, string fileName);
    Task DownloadObjectAsync(string bucket, string fileName, Stream destination);
    Task RemoveFileAsync(string bucketName, string fileName);
}