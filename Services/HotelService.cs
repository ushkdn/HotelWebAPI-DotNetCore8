using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelWebAPI_DotNetCore8.Services
{
    public class HotelService : IHotelService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public HotelService(DataContext context, IMapper mapper)
        {    
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetHotelDto>> CreateOne(AddHotelDto newHotel)
        {
            var serviceResponse = new ServiceResponse<GetHotelDto>();
            var hotel =_mapper.Map<Hotel>(newHotel);
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
            var mappedHotels = _mapper.Map<GetHotelDto>(hotel);
            serviceResponse.Data = mappedHotels;
            serviceResponse.Success = true;
            serviceResponse.Message = "New hotel added successfully.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetHotelDto>> DeleteOne(int id)
        {
            var serviceResponse = new ServiceResponse<GetHotelDto>();
            var hotel = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            serviceResponse.Data = null;
            serviceResponse.Success = true;
            serviceResponse.Message = "Hotel successfully deleted";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetHotelDto>>> GetAll()
        {   
            var serviceResponse = new ServiceResponse<List<GetHotelDto>>();
            var hotels = await _context.Hotels.ToListAsync();
            serviceResponse.Data = hotels.Select(c => _mapper.Map<GetHotelDto>(c)).ToList();
            serviceResponse.Success = true;
            serviceResponse.Message = "All hotels returned successfully.";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetHotelDto>> GetOne(int id)
        {
            var serviceResponse = new ServiceResponse<GetHotelDto>();
            var hotel = await _context.Hotels.FindAsync(id);
            serviceResponse.Data=_mapper.Map<GetHotelDto>(hotel);
            serviceResponse.Success = true;
            serviceResponse.Message = $"The hotel was successfully returned by ID: {id}";
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetHotelDto>> UpdateOne(int id, UpdateHotelDto updatedHotel)
        {
            var serviceResponse= new ServiceResponse<GetHotelDto>();
            var updtHotel = await _context.Hotels.FindAsync(id);
            _mapper.Map(updatedHotel, updtHotel);
            updtHotel.Name = updatedHotel.Name;
            updtHotel.Description = updatedHotel.Description;
            updtHotel.Location = updatedHotel.Location;
            updtHotel.RoomsNum = updatedHotel.RoomsNum;
            _context.Hotels.Update(updtHotel);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetHotelDto>(updtHotel);
            serviceResponse.Success = true;
            serviceResponse.Message = "Hotel successfully updated";
            return serviceResponse;
        }
    }
}
