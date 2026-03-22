using AssetTracker.Api.Service.Interface;
using AssetTracker.Api.Data;
using AssetTracker.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker.Api.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AssetDbContext _assetDbContext;

        public DepartmentService(AssetDbContext assetDbContext)
        {
            _assetDbContext = assetDbContext;
        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            var department = await _assetDbContext.Departments.ToListAsync();
            return department;
        }
    }
}
