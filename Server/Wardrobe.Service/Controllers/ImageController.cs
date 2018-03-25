using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe.DataAccess.Interfaces;
using Wardrobe.Model.Entities;

namespace Wardrobe.Service.Controllers
{
    [Route("/Image")]
    public class ImageController : Controller
    {
        private readonly IImageRepository Repository;

        public ImageController(IImageRepository repository)
        {
            Repository = repository;
        }

        [HttpGet("{id}", Name = "ImageGet")]
        public IActionResult Image(Guid id)
        {
            var img = Repository.GetImage(id);

            if (img == null)
            {
                throw new Exception("Image not found");
            }

            return base.File(img.ImageFile, "image/jpeg");
        }

        [HttpPost("Link/{id}", Name = "ImagePost")]
        public HttpResponseMessage PostImage()
        {
            var response = new HttpResponseMessage();
            var httpRequest = HttpContext.Request;

            var clothingItemId = httpRequest.Form["clothingItemId"];
            if (string.IsNullOrEmpty(clothingItemId))
            {
                throw new Exception("Error");
            }
            
            if (httpRequest.Form.Files.Count > 0)
            {
                foreach (var file in httpRequest.Form.Files)
                {
                    var image = new Image
                    {
                        Id = Guid.NewGuid(),
                        Name = file.FileName
                    };

                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        image.ImageFile = ms.ToArray(); 
                    }

                    Repository.AddImage(image);
                    Repository.LinkImageToClothingItem(imageId: image.Id, clothingItemId: Guid.Parse(clothingItemId));
                }
            }

            return response;
        }

        [HttpPost("Unlink", Name = "ImageUnlink")]
        public HttpResponseMessage UnlinkImage()
        {
            var response = new HttpResponseMessage();
            var httpRequest = HttpContext.Request;

            var clothingItemId = httpRequest.Form["clothingItemId"];
            var imageId = httpRequest.Form["imageId"];
            if (string.IsNullOrEmpty(clothingItemId)
                || string.IsNullOrEmpty(imageId))
            {
                throw new Exception("Error");
            }

            Repository.UnlinkImageToClothingItem(imageId: Guid.Parse(imageId), clothingItemId: Guid.Parse(clothingItemId));
            
            return response;
        }
    }
}