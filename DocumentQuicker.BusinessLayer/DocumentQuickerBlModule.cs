using Autofac;
using DocumentQuicker.BusinessLayer.Interfaces;
using DocumentQuicker.BusinessLayer.Services;

namespace DocumentQuicker.BusinessLayer
{
    public class DocumentQuickerBlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BankInfoService>()
                .As<IBankInfoService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<RequisiteService>()
                .As<IRequisiteService>()
                .InstancePerLifetimeScope();
        }
    }
}