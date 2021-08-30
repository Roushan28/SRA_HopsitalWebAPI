using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SRA_HopsitalWebAPI.Dtos.Register;
using SRA_HopsitalWebAPI.Models;
using SRA_HopsitalWebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRA_HopsitalWebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[controller]")]
    public class VaccineRegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public VaccineRegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _registerService.GetAllRegisters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _registerService.GetRegisterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddRegister(AddRegisterDto newRegister)
        {
            return Ok(await _registerService.AddRegister(newRegister));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRegister(UpdateRegisterDto updatedRegister)
        {
            ServiceResponse<GetRegisterDto> response = await _registerService.UpdateRegister(updatedRegister);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetRegisterDto>> response = await _registerService.DeleteRegister(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }

}
