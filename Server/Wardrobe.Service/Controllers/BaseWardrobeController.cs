using Microsoft.AspNetCore.Mvc;
using Wardrobe.DataAccess.Interfaces;

namespace Wardrobe.Service.Controllers
{
    public class BaseWardrobeController : Controller
    {
        protected readonly IWardrobeRepository Repository;

        public BaseWardrobeController(IWardrobeRepository repository)
        {
            Repository = repository;
        }
    }
}