using Domain.Users.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra
{
    public class APIDBContext : DbContext
    {
        //recebe os valores de dentro do appsetings.json
        private IConfiguration _configuration;

        //db transforma a requisição json para o objeto
        public DbSet<Users> Users { get; set; }

        public APIDBContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        // configuração de conexão com o DB
        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            try {
                
                optionsBuilder.UseMySQL(connectionString!);

            } catch {

                throw new InvalidOperationException();

            }
            
        }
    }
}
