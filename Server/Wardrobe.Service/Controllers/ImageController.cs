using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wardrobe.Service.Interfaces;

namespace Wardrobe.Service.Controllers
{
    [Route("/Image")]
    public class ImageController : BaseWardrobeController
    {
        private readonly IImageService _service;
        public ImageController(IImageService service, ILogger<LocationController> logger) : base(logger)
        {
            _service = service;
        }

        [HttpGet("{id}", Name = "ImageGet")]
        public IActionResult Image(Guid id)
        {
            var image = _service.GetImage(imageId: id);
            return File(image.ImageFile, "image/jpeg");
        }

        [HttpPost("Link/{id}", Name = "ImagePost")]
        public HttpResponseMessage PostImage()
        {
            
            var httpRequest = HttpContext.Request;
            var clothingItemId = httpRequest.Form["clothingItemId"];

            _service.UploadAndLinkImageToClothingItem(clothingItemId, httpRequest.Form.Files);

            return new HttpResponseMessage();
        }

        [HttpPost("Unlink", Name = "ImageUnlink")]
        public HttpResponseMessage UnlinkImage()
        {
            var httpRequest = HttpContext.Request;
            var clothingItemId = httpRequest.Form["clothingItemId"];
            var imageId = httpRequest.Form["imageId"];

            _service.UnlinkImageFromClothingItem(imageId: imageId, clothingItemId: clothingItemId);
            
            return new HttpResponseMessage();
        }
    }
}