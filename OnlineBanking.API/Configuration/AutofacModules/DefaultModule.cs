﻿using Autofac;
using OnlineBanking.BL;
 using OnlineBanking.BL.Services;

 namespace OnlineBanking.API.Configuration.AutofacModules
{
    /// <summary>
    /// Default module for Autofac
    /// </summary>
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MockBankEntitiesService>().As<IBankEntitiesService>().SingleInstance();
        }
    }
}
