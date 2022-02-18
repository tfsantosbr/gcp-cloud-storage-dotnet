using GCP.CloudStorage.Api.ExternalServices.Models;
using Google.Cloud.Storage.V1;

namespace GCP.CloudStorage.Api.ExternalServices;

public class FileStorage : IFileStorage
{
    private readonly StorageClient _storage;

    public FileStorage()
    {
        _storage = StorageClient.Create();
    }

    public async Task DownloadObjectAsync(string bucket, string fileName, Stream destination)
    {
        await _storage.DownloadObjectAsync(bucket, fileName, destination);
    }

    public async Task<FileStorageInfo?> GetFileInfoAsync(string bucket, string fileName)
    {
        var storageObject = await _storage.GetObjectAsync(bucket, fileName);

        if (storageObject is null)
            return null;

        var fileInfo = new FileStorageInfo
        {
            Id = storageObject.Id,
            MediaLink = storageObject.MediaLink,
            ContentType = storageObject.ContentType,
            Name = storageObject.Name,
            Size = storageObject.Size
        };

        return fileInfo;
    }

    public async Task UploadFileAsync(string bucket, string fileName, string contentType, Stream fileStream)
    {
        await _storage.UploadObjectAsync(bucket, fileName, contentType, fileStream);
    }
}