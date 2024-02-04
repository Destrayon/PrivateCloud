using Containers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Storage;

namespace PrivateCloud.Controllers
{
    [Route("cloud/api/image_repository")]
    [ApiController]
    public class ImageRepositoryController : ControllerBase
    {
        private readonly IImageRepositoryService _imageRepositoryService;

        public ImageRepositoryController(IImageRepositoryService imageRepositoryService)
        {
            _imageRepositoryService = imageRepositoryService;
        }
        [HttpPost("upload")]
        public IActionResult UploadContainerConfiguration([FromQuery]ImageRepositoryData imageRepositoryData, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is not uploaded");
            }

            _imageRepositoryService.CreateImageAsync(imageRepositoryData.ImageId, file.OpenReadStream(), imageRepositoryData.Version ?? "1.0");

            return Ok("File uploaded successfully.");
        }
    }
}
