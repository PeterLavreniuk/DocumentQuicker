using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using AutoMapper;
using DocumentQuicker.BusinessLayer;
using DocumentQuicker.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;

namespace DocumentQuicker.Api
{
    public sealed class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DocumentQuickerBlModule());

            builder.Register(c => new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(Assembly.GetExecutingAssembly());
                    cfg.AddMaps(Assembly.GetAssembly(typeof(DocumentQuickerBlModule)));
                })
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .SingleInstance();
            
            builder.Register(c =>
                {
                    var configuration = c.Resolve<IConfiguration>();
                    var dbContextOptions = new DbContextOptions<DocumentQuickerContext>(new Dictionary<Type, IDbContextOptionsExtension>());
                    var optionsBuilder = new DbContextOptionsBuilder<DocumentQuickerContext>(dbContextOptions);
                    
                    optionsBuilder.UseMySQL((string) configuration.GetConnectionString("Database"));
                    return optionsBuilder.Options;
                })
                .As<DbContextOptions<DocumentQuickerContext>>()
                .InstancePerLifetimeScope();
            
            builder.Register(context => context.Resolve<DbContextOptions<DocumentQuickerContext>>())
                .As<DbContextOptions>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DocumentQuickerContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}