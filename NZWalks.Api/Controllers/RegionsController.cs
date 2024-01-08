using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.DTO;
using NZWalks.Api.Repository;

namespace NZWalks.Api.Controllers
{
    //Used to define api||[controller] means controller class name|| Can also write as("api/regions")
    //GET: https//7180:portnumber/api/regions
    [Route("api/[controller]")]
    //Tells Application that this controller is for APi use
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        //Constructor Injection
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository) //Ctrl+. to create and assign field "dbContext"
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        //IActionResult is Response type
        [HttpGet]
        public IActionResult GetAll()
        {
            /* var regions = new List<Region>
             {
                 new Region{
                 Id=Guid.NewGuid(),
                 Name="Auckland Region",
                 Code="AKL",
                 RegionImageUrl=null
                 },
                 new Region
                 {
                     Id=Guid.NewGuid(),
                     Name="Wellington Region",
                     Code="WLG",
                     RegionImageUrl=null
                 }
             };*/

            //Get Data From Database
           //var regions= dbContext.Regions.ToList();

            //Get Data through Repository from database
            var regions = regionRepository.GetAllRegion();

            //Map Data to Dto
            var regionDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionDto.Add(new RegionDto()
                {
                    Name = region.Name,
                    Id = region.Id,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            //Return Dto
            return Ok(regionDto);
        }


        //Get Region By Id
        //https//7180:portnumber/api/regions/id
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {
            //Get Data From Db
            //var region = dbContext.Regions.Find(id);

            //Get Data from db through repository
            var region=regionRepository.GetRegionById(id);

            //Find() only takes primary key as input
            //Alternative Way
            //var region2= dbContext.Regions.FirstOrDefault(x => x.Id == id);
            //var region2= dbContext.Regions.FirstOrDefault(x => x.Name == name);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
            
        }

        [HttpPost]
        public IActionResult CreateRegion([FromBody] RegionRequestDto regionRequestDto) 
        {
            var region = new Region {
                Name = regionRequestDto.Name,
                Code= regionRequestDto.Code,
                RegionImageUrl = regionRequestDto.RegionImageUrl
            };

            //dbContext.Regions.Add(region);
            //dbContext.SaveChanges();

            region= regionRepository.CreateRegion(region);

            var regionDto = new RegionDto {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = regionRequestDto.RegionImageUrl
            };


            return CreatedAtAction(nameof(GetById), new {id=regionDto.Id}, regionDto);
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] RegionRequestDto regionDto)
        {
            var regionModel = new Region
            {
                Code = regionDto.Code,
                Name = regionDto.Name,
                RegionImageUrl = regionDto.RegionImageUrl,
            };

            var region = regionRepository.UpdateRegion(id, regionModel);

            if (region == null) { return NotFound(); }

            var savedRegionDto = new RegionDto { 
                Id=region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(savedRegionDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            var region=regionRepository.DeleteRegion(id);
            if (region == null) { return NotFound(); }
            return Ok();
        }
    }
}
