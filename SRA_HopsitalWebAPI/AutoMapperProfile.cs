using System.Linq;
using AutoMapper;
using SRA_HopsitalWebAPI.Dtos;
using SRA_HopsitalWebAPI.Dtos.Register;
using SRA_HopsitalWebAPI.Models;

namespace SRA_HopsitalWebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Register, GetRegisterDto>();
            CreateMap<AddRegisterDto, Register>();

        }
    }
}