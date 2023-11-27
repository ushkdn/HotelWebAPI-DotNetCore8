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
        public IHotelService _hotelService { get; }

        public HotelController(IHotelService hotelService) {
            _hotelService = hotelService;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetHotelDto>>> CreateOne(AddHotelDto newHotel)
        {
            return Ok(await _hotelService.CreateOne(newHotel));
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<GetHotelDto>>> DeleteOne(int id)
        {
            return Ok(await _hotelService.DeleteOne(id));
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetHotelDto>>>> GetAll()
        {
            return Ok(await _hotelService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetHotelDto>>> GetOne(int id)
        {
            return Ok(await _hotelService.GetOne(id));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetHotelDto>>> UpdateOne(int id, UpdateHotelDto updatedHotel)
        {
            return Ok(await _hotelService.UpdateOne(id, updatedHotel));
        }

    }
}
