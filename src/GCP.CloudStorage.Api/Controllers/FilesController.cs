using GCP.CloudStorage.Api.ExternalServices.FileStorage;
using Microsoft.AspNetCore.Mvc;

namespace GCP.CloudStorage.Api.Controllers;

[ApiController]
[Route("files")]
public class FilesController : ControllerBase
{
    private readonly ILogger<FilesController> _logger;
    private readonly IFileStorage _fileStorage;

    public FilesController(ILogger<FilesController> logger, IFileStorage fileStorage)
    {
        _logger = logger;
        _fileStorage = fileStorage;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFile([FromForm] IFormFile file)
    {
        var fileName = file.FileName;
        var contentType = file.ContentType;
        var fileStream = file.OpenReadStream();

        await _fileStorage.UploadFileAsync("tfsantosbr-images", fileName, contentType, fileStream);

        return Ok();
    }

    [HttpGet("{fileName}/info")]
    public async Task<IActionResult> GetFile(string fileName)
    {
        var fileInfo = await _fileStorage.GetFileInfoAsync("tfsantosbr-images", fileName);

        return Ok(fileInfo);
    }

    [HttpGet("{fileName}/download")]
    public async Task<IActionResult> DownloadFile(string fileName)
    {
        var fileInfo = await _fileStorage.GetFileInfoAsync("tfsantosbr-images", fileName);

        if (fileInfo is null)
            return NotFound();

        var contentType = fileInfo.ContentType;
        var downloadName = fileInfo.Name;

        var stream = new MemoryStream();

        await _fileStorage.DownloadObjectAsync("tfsantosbr-images", fileName, stream);

        stream.Seek(0, SeekOrigin.Begin);

        return File(stream, contentType, downloadName);
    }
}
