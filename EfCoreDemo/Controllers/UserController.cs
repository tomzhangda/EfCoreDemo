using EfCoreDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _db;

        public UserController(DataContext db)
        {
            _db = db;
        }

        [HttpPost("createclass")]
        public async Task<ActionResult<Class>> CreateClass(Class model)
        {
            if (ModelState.IsValid)
            {
                _db.Classes.Add(model);
                await _db.SaveChangesAsync();

                return Ok(model);
            }

            return BadRequest("error");
        }

        [HttpGet("classes")]
        public async Task<ActionResult<List<Class>>> GetAllClasses()
        {
            return await _db.Classes.ToListAsync();
        }

        [HttpPost("createstudent")]
        public async Task<ActionResult<User>> CreateUser(User model)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(model);
                await _db.SaveChangesAsync();
                return Ok(model);
            }

            return BadRequest("err");
        }

        [HttpGet("students")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _db.Users.Include(m=>m.Class).ToListAsync();
        }
    }
}
