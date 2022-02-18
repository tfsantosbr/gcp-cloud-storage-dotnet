namespace GCP.CloudStorage.Api.ExternalServices.Models;

public class FileStorageInfo
{
    public string Id { get; set; } = null!;
    public string MediaLink { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ulong? Size { get; set; }
}