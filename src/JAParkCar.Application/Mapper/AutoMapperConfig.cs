using AutoMapper;
using JAParkCar.Application.DTO.Car;
using JAParkCar.Domain.Models;

namespace JAParkCar.Application.Mapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Car, CarCreateDto>().ReverseMap();
        CreateMap<Car, CarUpdateDto>().ReverseMap();
        CreateMap<Car, CarGetDto>().ReverseMap();
    }
}