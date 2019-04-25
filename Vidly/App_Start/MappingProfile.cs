using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public IMapper Mapper { get; }
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();
            });

            Mapper = config.CreateMapper();
        }
    }
}