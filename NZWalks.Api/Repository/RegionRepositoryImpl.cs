using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repository
{
    public class RegionRepositoryImpl : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public RegionRepositoryImpl(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Region CreateRegion(Region region)
        {
             dbContext.Regions.Add(region);
            dbContext.SaveChanges();
            return region;

        }

        public Region? DeleteRegion(Guid id)
        {
            var existingRegion=dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (existingRegion == null) { return null; }
            dbContext.Regions.Remove(existingRegion);
            dbContext.SaveChanges ();
            return existingRegion;
        }

        public List<Region> GetAllRegion()
        {
            return dbContext.Regions.ToList();
        }

        public Region? GetRegionById(Guid id)
        {
           return dbContext.Regions.FirstOrDefault(r => r.Id == id);
        }

        public Region? UpdateRegion(Guid id, Region region)
        {
            var existingRegion = dbContext.Regions.FirstOrDefault(s => s.Id == id);
            if (existingRegion == null) { return null; }

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;
            dbContext.SaveChanges();
            return existingRegion;
        }
    }
}
