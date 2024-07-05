using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace _6thElement.Application.Images;

public class ImageService
{
    private readonly IConfiguration _config;

    public ImageService(IConfiguration config)
    {
        _config = config;
    }

    


    private async Task<(string, string)> SaveImage(IFormFile file, CancellationToken token)
    {

        var path = _config["Constants:UploadsFolderPath"];
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        var ext = Path.GetExtension(file.FileName).ToLower();
        var allowedExtensions = new string[] { ".jpg", ".png", ".jpeg" };

        if (!allowedExtensions.Contains(ext))
            throw new Exception("Not Allowed File Exstension");

        var uniqueString = Guid.NewGuid().ToString();
        var fileName = uniqueString + ext;
        var filePath = Path.Combine(path, fileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream, token);
            await stream.FlushAsync(token);
        }

        return (string.Format("/{0}/{1}", _config["Constants:ResourcePath"], fileName), filePath);
    }
}
