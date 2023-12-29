using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileService.Models;

namespace profileService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileContext _context;
        public ProfileController(ProfileContext context)
        {
            _context = context;
        }

        //GET : api/Profile
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Profiles>>> Get([FromBody] Profiles usr)
        {

            if(usr.Valid)
            {
            var result = await _context.Profile.Where(s => s.Email == usr.Email).ToListAsync();
            return result;
            }
            else
            {
                return BadRequest();
            }

        }
        

    }

}





    

