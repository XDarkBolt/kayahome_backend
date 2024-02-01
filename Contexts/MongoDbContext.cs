using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using kayahome_backend.Contexts;
using MongoDB.EntityFrameworkCore.Extensions;
using kayahome_backend.Contexts.Sets;

namespace kayahome_backend.Contexts
{
    public class MongoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            var mongoClient = new MongoClient("mongodb+srv://Kaya:Hk1996.u@kayahomecluster.6akmaxf.mongodb.net/?retryWrites=true&w=majority");
            dbContextOptions.UseMongoDB(mongoClient, "Automation");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MongoBase>().ToCollection("MongoNetCore");
        }

        public DbSet<MongoBase> MongoBase { get; init; }
    }
}
