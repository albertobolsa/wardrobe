using System;
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
    }
}