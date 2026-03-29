using AssetTracker.Api.Model;
using AssetTracker.Api.Dto.DepartmentDto;

namespace AssetTracker.Api.Service.Interface
{
    public interface IDepartmentService
    {
        Task<List<GetAllDepartmentDto>> GetAllDepartmentAsync();

        Task CreateDepartmentAsync(CreateDepartmentDto dto);

        Task PatchDepartmentAsync(PatchDepartmentDto dto, int departmentId);

        Task DeleteDepartmentAsync(int departmentId);
    }
}
