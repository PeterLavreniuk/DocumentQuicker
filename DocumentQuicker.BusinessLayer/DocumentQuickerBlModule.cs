using System.Reflection;
using Autofac;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Services;
using Module = Autofac.Module;

namespace DocumentQuicker.BusinessLayer
{
    public class DocumentQuickerBlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BankService>()
                .As<IBankService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RequisiteService>()
                .As<IRequisiteService>()
                .InstancePerLifetimeScope();
        }
    }
}