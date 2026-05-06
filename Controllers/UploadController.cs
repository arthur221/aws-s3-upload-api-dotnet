using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("upload")]
public class UploadController : ControllerBase
{
    private readonly S3Service _s3Service;

    public UploadController(S3Service s3Service)
    {
        _s3Service = s3Service;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)    {
        if (file == null || file.Length == 0)
            return BadRequest("Arquivo inválido");

        await _s3Service.UploadFileAsync(file);

        return Ok("Arquivo enviado com sucesso!");
    }
}