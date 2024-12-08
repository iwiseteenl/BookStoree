using BookStoree.ActionClass.Account;
using BookStoree.Interface;
using BookStoree.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IUser iUser) : ControllerBase
    {
        private readonly IUser _IUser = iUser;

        [HttpGet("Persons")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Client>>> Get() => await Task.FromResult(_IUser.GetClient());

        [HttpDelete("Persons/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(int id) => await Task.FromResult(_IUser.DeleteClient(id));

        [HttpGet("Persons/{name}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Client>>> Get(string name) => await Task.FromResult(_IUser.GetClient(name));

        [HttpPost("Persons/addAccount")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<List<string>>> Post(AccountCreatecs userData) => await Task.FromResult(_IUser.AddAccount(userData));
    }
}
