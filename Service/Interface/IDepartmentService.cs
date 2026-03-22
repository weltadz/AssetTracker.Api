using AssetTracker.Api.Model;

namespace AssetTracker.Api.Service.Interface
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartmentAsync();
    }
}
