using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LibraryWebApplication.Departments.Dto;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Abp.IdentityFramework;
using LibraryWebApplication.Authorization;
using Abp.Authorization;

namespace LibraryWebApplication.Departments
{
    [AbpAuthorize(PermissionNames.Pages_Departments)]
    public class DepartmentService : AsyncCrudAppService<Department, DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>, IDepartmentService
    {
        private readonly IRepository<Department> _departmentsRepository;

        public DepartmentService(
            IRepository<Department> departmentRepository)
            : base(departmentRepository)
        {
            _departmentsRepository = departmentRepository;
        }

        public override async Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            CheckCreatePermission();

            // Create department
            var department = ObjectMapper.Map<Department>(input);
            await _departmentsRepository.InsertAsync(department);
            await CurrentUnitOfWork.SaveChangesAsync(); // To get new department's id.

            return MapToEntityDto(department);
        }

        protected override IQueryable<Department> CreateFilteredQuery(PagedDepartmentResultRequestDto input)
        {
            return Repository.GetAll();              
        }

        protected override void MapToEntity(DepartmentDto updateInput, Department entity)
        {        
            entity.DepartmentName = updateInput.DepartmentName;
            entity.CreationDate = updateInput.CreatedDate;
            entity.Description = updateInput.Description;
            entity.Remarks = updateInput.Remarks;
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var dept = await _departmentsRepository.GetAsync(input.Id);
            await _departmentsRepository.DeleteAsync(dept);
        }

        private void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
