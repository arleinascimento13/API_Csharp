using Infra;
using Domain.Users.Entity;
using Microsoft.AspNetCore.Mvc;
using Interfaces;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<Users> _usersRepository;
        public UserController(IRepository<Users> repository)
        {
            _usersRepository = repository;
        }

        [HttpGet("{id}")]
        public List<Users> Get()
        {
            return _usersRepository.Get();
        }

        [HttpPost]
        public void Post([FromBody]Users user)
        {
            _usersRepository.Post(user);
        }

        [HttpPatch]
        public void Update(int id)
        {
            //_usersRepository.Patch(id);
            // depois eu faço a logica disso aqui
        }

        [HttpDelete]
        public void Delete([FromRoute]int id)
        {
            _usersRepository.Delete(id);
        }
    }
}
