using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Wardrobe.Service.Controllers
{
    public class BaseWardrobeController : Controller
    {
        protected readonly ILogger Logger;

        public BaseWardrobeController(ILogger logger)
        {
            Logger = logger;
        }
    }
}