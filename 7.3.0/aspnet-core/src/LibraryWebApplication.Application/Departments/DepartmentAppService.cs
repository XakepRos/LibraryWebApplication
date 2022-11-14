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
using System.Collections.Generic;

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
                //input.CreationTime = DateTime.Now;
                //var entity = MapToEntity(input);

                var entities = new Department();
                entities.IsActive = input.IsActive;
                entities.CreationTime = DateTime.Now;
                entities.Remarks = input.Remarks;
                entities.DepartmentName = input.DepartmentName;
                entities.Description = input.Description;
                
                await _departmentsRepository.InsertAsync(entities);



                //await _departmentsRepository.InsertAsync(department);
               // _mapper.Map<DepartmentDto>(_departmentsRepository.InsertAsync(entity));

                await CurrentUnitOfWork.SaveChangesAsync(); // To get new department's id.

                return new DepartmentDto();

            }
            catch (Exception ex)
            {
                throw ex;//new UserFriendlyException("Cann't create department");
            }
        }

        protected List<Department> CreateFilteredQuery(PagedDepartmentResultRequestDto input)
        {
            try
            {

                var data = _departmentsRepository.GetAllList()
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive).ToList();

                return data;
            }
            catch (Exception ex)
            {
                throw ex;//new UserFriendlyException("Cann't get all created department list");
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
