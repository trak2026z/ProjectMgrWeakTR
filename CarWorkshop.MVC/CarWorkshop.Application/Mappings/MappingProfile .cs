using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(dest => dest.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));
        }
    }
}
