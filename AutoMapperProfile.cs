namespace HotelWebAPI_DotNetCore8
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Hotel, GetHotelDto>();
            CreateMap<AddHotelDto,Hotel>();
            CreateMap<UpdateHotelDto,Hotel >();
        }
    }
}
