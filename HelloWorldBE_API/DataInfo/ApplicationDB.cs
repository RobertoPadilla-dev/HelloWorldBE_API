using HelloWorldBE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldBE_API.Data
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options)
            : base(options)
        {
        }

        public DbSet<Mensaje> Mensajes { get; set; }

    }
}
