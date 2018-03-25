using Wardrobe.DataAccess.Context;
using Wardrobe.DataAccess.Interfaces;

namespace Wardrobe.DataAccess.Repository
{
    public partial class WardrobeRepository : IWardrobeRepository
    {
        private readonly WardrobeDataContext _context;

        public WardrobeRepository(WardrobeDataContext dbContext)
        {
            _context = dbContext;
        }        
    }
}
