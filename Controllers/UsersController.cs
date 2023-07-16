using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinkHubApi.CodeFirstMigration.Data;
using LinkHubApi.CodeFirstMigration.Entities;
using LinkHubApi.Entities.ViewModel;
using LinkHubApi.Services;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LinkHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly AppDbContext _context;

        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var result= await _userService.GetUsersAsync();
            if(result==null)
                return NotFound();
            return Ok(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var jsonresult =JsonSerializer.Serialize( _userService.GetUserById(id));
            
            if(jsonresult != null)
                return Ok(jsonresult);

            return NotFound(jsonresult);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User user)
        {
           var result= _userService.UpdateUserAsync(id, user);
            if (result.Result != null)
                return Ok(user);
            return NotFound();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var result = _userService.AddUserAsync(user);
            if(result.Result!=null)
                return Ok(user);
            return NotFound();

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if(_userService.DeleteUser(id)!=null)
                return Ok();

            return NoContent();
        }

   
    }
}
