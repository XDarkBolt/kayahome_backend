using kayahome_backend.Contexts.Sets;
using Microsoft.EntityFrameworkCore;

namespace kayahome_backend.Contexts
{
    public class KayaHomeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=mysql02.trwww.com; user=kayahuse_Kaya; database=kayahuse_KayaHome; password=J@5sz-%[_DJg;", ServerVersion.AutoDetect("server=mysql02.trwww.com; user=kayahuse_Kaya; database=kayahuse_KayaHome; password=J@5sz-%[_DJg;"));
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<HubConnection> HubConnection { get; set; }
    }
}
