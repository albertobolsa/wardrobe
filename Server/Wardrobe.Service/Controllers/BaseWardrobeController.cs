using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wardrobe.DataAccess.Interfaces;

namespace Wardrobe.Service.Controllers
{
    public class BaseWardrobeController : Controller
    {
        protected readonly IWardrobeRepository Repository;
        protected readonly ILogger Logger;

        public BaseWardrobeController(IWardrobeRepository repository, ILogger logger)
        {
            Repository = repository;
            Logger = logger;
        }
    }
}