using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelWebAPI_DotNetCore8.Services
{
    public interface IHotelService 
    {
        Task<ServiceResponse<GetHotelDto>> CreateOne(AddHotelDto newHotel);
        Task<ServiceResponse<List<GetHotelDto>>> GetAll();
        Task<ServiceResponse<GetHotelDto>> GetOne(int id);
        Task<ServiceResponse<GetHotelDto>> DeleteOne(int id);
        Task<ServiceResponse<GetHotelDto>> UpdateOne(int id, UpdateHotelDto updatedHotel);
    }
}
