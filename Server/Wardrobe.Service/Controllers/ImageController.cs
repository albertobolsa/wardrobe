using Microsoft.AspNetCore.Mvc;

namespace Wardrobe.Service.Controllers
{
    [Route("/Image")]
    public class ImageController : Controller
    {
        [HttpGet]
        public IActionResult Image()
        {
            return base.File(@"Image path", "image/jpeg");
        }
    }
}