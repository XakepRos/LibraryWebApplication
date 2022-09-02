﻿using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LibraryWebApplication.EntityFrameworkCore;
using LibraryWebApplication.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LibraryWebApplication.Web.Tests
{
    [DependsOn(
        typeof(LibraryWebApplicationWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LibraryWebApplicationWebTestModule : AbpModule
    {
        public LibraryWebApplicationWebTestModule(LibraryWebApplicationEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LibraryWebApplicationWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LibraryWebApplicationWebMvcModule).Assembly);
        }
    }
}