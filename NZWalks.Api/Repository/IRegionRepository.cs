using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repository
{
    public interface IRegionRepository
    {
        List<Region> GetAllRegion();

        Region? GetRegionById(Guid id);

        Region CreateRegion(Region region);

        Region? UpdateRegion(Guid id, Region region);

        Region? DeleteRegion(Guid id);

    }
}
