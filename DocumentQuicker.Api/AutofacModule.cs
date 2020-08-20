using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using DocumentQuicker.BusinessLayer;
using DocumentQuicker.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace DocumentQuicker.Api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DocumentQuickerBlModule());

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();
            
            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
            
            builder.Register(c =>
                {
                    var serviceProvider = c.Resolve<IServiceProvider>();
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