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
using static LibraryWebApplication.Authorization.Roles.StaticRoleNames;
using Abp.MultiTenancy;
using Abp.Collections.Extensions;
using AutoMapper;
using System;
using Abp.Domain.Entities;
using Abp.Extensions;
using Abp.UI;
using LibraryWebApplication.Authorization.Roles;
using Abp.Runtime.Security;
using LibraryWebApplication.MultiTenancy;
using Abp.AutoMapper;
using static AutoMapper.Internal.ExpressionFactory;

namespace LibraryWebApplication.Departments
{
    //[AbpAuthorize(PermissionNames.Pages_Departments)]
    public class DepartmentAppService : AsyncCrudAppService<Department, DepartmentDto, int, PagedDepartmentResultRequestDto, CreateDepartmentDto, DepartmentDto>, IDepartmentAppService
    {
        private readonly IRepository<Department> _departmentsRepository;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;
        private readonly RoleManager _roleManager;
        private readonly IMapper _mapper;

        public DepartmentAppService(
            IRepository<Department> departmentRepository,
            IAbpZeroDbMigrator abpZeroDbMigrator,
            RoleManager roleManager,
            IMapper mapper)
            : base(repository: departmentRepository)
        {
            _departmentsRepository = departmentRepository;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public override async Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            try
            {
                CheckCreatePermission();

                // Create department
                //var department = ObjectMapper.Map<Department>(input);

                var entity = MapToEntity(input);

                await Repository.InsertAsync(entity);

                //await _departmentsRepository.InsertAsync(department);
               // _mapper.Map<DepartmentDto>(_departmentsRepository.InsertAsync(entity));

                await CurrentUnitOfWork.SaveChangesAsync(); // To get new department's id.

                return MapToEntityDto(entity);

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Cann't create department");
            }
        }

        protected override IQueryable<Department> CreateFilteredQuery(PagedDepartmentResultRequestDto input)
        {
            try
            {
                return Repository.GetAll()
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive).AsQueryable();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Cann't get all created department list");
            }

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

        private void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
