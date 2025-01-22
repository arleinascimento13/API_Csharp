using Infra;
using Domain.Users.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private APIDBContext _dbConnection;

        public UserController(APIDBContext dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _dbConnection.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Add(Users user)
        {
            var users = _dbConnection.Users.Add(user);
            _dbConnection.SaveChanges();
            return Ok(users.Entity);
        }
    }
}
