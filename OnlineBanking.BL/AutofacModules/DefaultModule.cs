using Autofac;
using AutoMapper;
using OnlineBanking.BL.Services;
using OnlineBanking.Data.Repo;

namespace OnlineBanking.BL.AutofacModules
{
    /// <summary>
    /// Default module for Autofac
    /// </summary>
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RealBankEntitiesService>().As<IBankEntitiesService>().SingleInstance();
            builder.RegisterType<TransactionsRepo>().As<ITransactionsRepo>().SingleInstance();
            builder.RegisterType<ShopsRepo>().As<IShopsRepo>().SingleInstance();
        }
    }
}
