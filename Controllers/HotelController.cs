using HotelWebAPI_DotNetCore8.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HotelWebAPI_DotNetCore8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly DataContext _context;
        public HotelController(DataContext context) {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Hotel>> CreateOne(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            return Ok(hotel);
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetAll()
        {
            var hotels = await _context.Hotels.ToListAsync();
            if(hotels is null) {
                return NotFound($"Hotels not found");
            }
            return Ok(hotels);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetOne(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel is null) {
                return NotFound($"Hotel with Id {id} not found");
            }
            return Ok(hotel);
        }
        [HttpDelete]
        public async Task<ActionResult<List<Hotel>>> DeleteOne(int id)
        {
            var hotel=await _context.Hotels.FindAsync(id);
            if (hotel is null) {
                return NotFound($"Hotle with id: {id} not found.");
            }
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return Ok($"Hotel with id {id} deleted");   

        }
    }
}
