using System.Collections.Generic;
using System.Threading.Tasks;
using SRA_HopsitalWebAPI.Dtos.Register;
using SRA_HopsitalWebAPI.Models;

namespace SRA_HopsitalWebAPI.Services
{
    public interface IRegisterService
    {
         Task<ServiceResponse<List<GetRegisterDto>>> GetAllRegisters();
         Task<ServiceResponse<GetRegisterDto>> GetRegisterById(int id);
         Task<ServiceResponse<List<GetRegisterDto>>> AddRegister(AddRegisterDto newRegister);
         Task<ServiceResponse<GetRegisterDto>> UpdateRegister(UpdateRegisterDto updatedRegister);
         Task<ServiceResponse<List<GetRegisterDto>>> DeleteRegister(int id);
    }
}