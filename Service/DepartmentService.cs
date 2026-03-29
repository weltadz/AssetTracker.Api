using AssetTracker.Api.Service.Interface;
using AssetTracker.Api.Data;
using AssetTracker.Api.Model;
using AssetTracker.Api.Dto.DepartmentDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AssetTracker.Api.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AssetDbContext _assetDbContext;

        public DepartmentService(AssetDbContext assetDbContext)
        {
            _assetDbContext = assetDbContext;
        }

        //Get all department
        public async Task<List<GetAllDepartmentDto>> GetAllDepartmentAsync()
        {
            var department = await _assetDbContext.Departments.ToListAsync();

            return department.Select(d => new GetAllDepartmentDto
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.Name

            }).ToList();
        }

        //Create department
        public async Task CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto),"Invalid parameter");
            }

            if(string.IsNullOrWhiteSpace(dto.DepartmentName))
            {
                throw new ArgumentException("Department name must not be empty");
            }

            var exist = await _assetDbContext.Departments
                .AnyAsync(d => d.Name == dto.DepartmentName);

            if(exist)
            {
                throw new ArgumentException("Department already exists");
            }

            var department = new Department
            {
                Name = dto.DepartmentName
            };

            await _assetDbContext.Departments.AddAsync(department);
            await _assetDbContext.SaveChangesAsync();

        }

        //Patch department
        public async Task PatchDepartmentAsync(PatchDepartmentDto dto, int departmentId)
        {
            var department = await _assetDbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if(department == null)
            {
                throw new KeyNotFoundException("Department not found");
            }

            department.Name = string.IsNullOrWhiteSpace(dto.Name) ? department.Name : dto.Name;

            await _assetDbContext.SaveChangesAsync();

        }

        //Delete department
        public async Task DeleteDepartmentAsync(int departmentId)
        {
            var department = await _assetDbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

            if (department == null)
            {
                throw new KeyNotFoundException("Department not found");
            }

            _assetDbContext.Departments.Remove(department);
            await _assetDbContext.SaveChangesAsync();

        }
    }
}
