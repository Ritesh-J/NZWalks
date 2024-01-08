namespace NZWalks.Api.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        //string? means it can have null values as well
        public string? RegionImageUrl { get; set; }




    }
}
