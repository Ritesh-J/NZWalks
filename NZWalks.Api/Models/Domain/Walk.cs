using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        //Mapping of Difficult Entity With Walk Entity
        public Guid DifficultId { get; set; }
        public Guid RegionId { get; set; }
        //Navigation Properties
        //This Defines 1:1 relationship b/w Walk and Difficulty
        public Difficulty Difficulty { get; set; }
        //This Defines 1:1 relationship b/w Walk and Region
        public Region Region { get; set; }







    }
}
