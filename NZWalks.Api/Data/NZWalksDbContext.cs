using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Data
{
    //Press Ctrl+. to import package
    public class NZWalksDbContext : DbContext 
    {
        //Create a constructor
        //To create a constructor ctor+DTab
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                
        }
        //A DBSet is a property of DbContextClass that represents the
        //Collection of properties of all entities

        //These below properties will create table in Database
        public DbSet<Difficulty> Difficulties  { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

    }
}
