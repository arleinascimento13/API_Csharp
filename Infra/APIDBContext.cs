using Domain.Users.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra
{
    public class APIDBContext : DbContext
    {
        //recebe os valores de dentro do appsetings.json
        private IConfiguration _configuration;

        public DbSet<Users> Users { get; set; }

        public APIDBContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        // configuração de conexão com o DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
