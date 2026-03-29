using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssetTracker.Api.Service.Interface;
using AssetTracker.Api.Dto.DepartmentDto;

namespace AssetTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }


        //Get all department
        [HttpGet]
        public async Task<IActionResult> GetAllDepartmentAsync()
        {
            var success = await _departmentService.GetAllDepartmentAsync();
            return Ok(new { Department = success });
        }

        //Create department
        [HttpPost]
        public async Task<IActionResult> CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            try
            {
                await _departmentService.CreateDepartmentAsync(dto);
                return Ok(new { message = "Department successfully created" });

            }catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });

            }
            
        }

        //Patch department
        [HttpPatch("{departmentId}")]
        public async Task<IActionResult> PatchDepartmentAsync(PatchDepartmentDto dto, int departmentId)
        {
            try
            {
                await _departmentService.PatchDepartmentAsync(dto, departmentId);
                return Ok(new { message = "Update department successfully" });

            }catch(KeyNotFoundException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //Delete department
        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int departmentId)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(departmentId);
                return Ok(new { message = "Department successfully deleted" });

            }catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
