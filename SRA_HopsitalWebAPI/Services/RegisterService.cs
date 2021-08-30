using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using SRA_HopsitalWebAPI.Data;
using SRA_HopsitalWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SRA_HopsitalWebAPI.Dtos.Register;

namespace SRA_HopsitalWebAPI.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;           
           
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        public async Task<ServiceResponse<List<GetRegisterDto>>> AddRegister(AddRegisterDto newRegister)
        {
            ServiceResponse<List<GetRegisterDto>> serviceResponse = new ServiceResponse<List<GetRegisterDto>>();
            Register Register = _mapper.Map<Register>(newRegister);
            Register.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            await _context.Registers.AddAsync(Register);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Registers.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetRegisterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRegisterDto>>> DeleteRegister(int id)
        {
            ServiceResponse<List<GetRegisterDto>> serviceResponse = new ServiceResponse<List<GetRegisterDto>>();
            try
            {
                Register Register = await _context.Registers
                    .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
                if (Register != null)
                {
                    _context.Registers.Remove(Register);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = (_context.Registers.Where(c => c.User.Id == GetUserId())
                        .Select(c => _mapper.Map<GetRegisterDto>(c))).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Register not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetRegisterDto>>> GetAllRegisters()
        {
            ServiceResponse<List<GetRegisterDto>> serviceResponse = new ServiceResponse<List<GetRegisterDto>>();
            List<Register> dbRegisters =
                  GetUserRole().Equals("Admin") ?
                await _context.Registers.ToListAsync() :
                await _context.Registers.Where(c => c.User.Id == GetUserId()).ToListAsync();
            serviceResponse.Data = (dbRegisters.Select(c => _mapper.Map<GetRegisterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRegisterDto>> GetRegisterById(int id)
        {
            ServiceResponse<GetRegisterDto> serviceResponse = new ServiceResponse<GetRegisterDto>();
            Register dbRegister = await _context.Registers
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetRegisterDto>(dbRegister);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRegisterDto>> UpdateRegister(UpdateRegisterDto updatedRegister)
        {
            ServiceResponse<GetRegisterDto> serviceResponse = new ServiceResponse<GetRegisterDto>();
            try
            {
                Register Register = await _context.Registers.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == updatedRegister.Id);
                if (Register.User.Id == GetUserId())
                {
                    Register.Name = updatedRegister.Name;
                    Register.IdentityNo= updatedRegister.IdentityNo;
                    Register.NoofDependent = updatedRegister.NoofDependent;
                    Register.AvailableDate = updatedRegister.AvailableDate;
                   
                    _context.Registers.Update(Register);
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetRegisterDto>(Register);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Register not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}