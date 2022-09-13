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
using LibraryWebApplication.MultiTenancy;
using static LibraryWebApplication.Authorization.Roles.StaticRoleNames;
using Abp.MultiTenancy;
using Abp.Collections.Extensions;
using AutoMapper;
using System;

namespace LibraryWebApplication.Departments
{
    [AbpAuthorize(PermissionNames.Pages_Departments)]
    public class DepartmentService : AsyncCrudAppService<Department, DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>, IDepartmentService
    {
        private readonly IRepository<Department> _departmentsRepository;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;

        public DepartmentService(
            IRepository<Department> departmentRepository,
            IAbpZeroDbMigrator abpZeroDbMigrator)
            : base(departmentRepository)
        {
            _departmentsRepository = departmentRepository;
            _abpZeroDbMigrator = abpZeroDbMigrator;
        }

        public override async Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            CheckCreatePermission();

            // Create department
            var department = ObjectMapper.Map<Department>(input);
            await _departmentsRepository.CountAsync();

            await _departmentsRepository.InsertAsync(department);
            await CurrentUnitOfWork.SaveChangesAsync(); // To get new department's id.

            // Create department database
            _abpZeroDbMigrator.CreateOrMigrateForHost();

            
            return MapToEntityDto(department);
        }

        protected override IQueryable<Department> CreateFilteredQuery(PagedDepartmentResultRequestDto input)
        {
            return (IQueryable<Department>)Repository.GetAll()
                 .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);               
        }

        protected override void MapToEntity(DepartmentDto updateInput, Department entity)
        {        
            entity.DepartmentName = updateInput.DepartmentName;
            entity.CreationTime = updateInput.CreationTime;
            entity.Description = updateInput.Description;
            entity.Remarks = updateInput.Remarks;
            entity.IsActive = updateInput.IsActive;
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var dept = await _departmentsRepository.GetAsync(input.Id);
            await _departmentsRepository.DeleteAsync(dept);
        }   
    }
}
