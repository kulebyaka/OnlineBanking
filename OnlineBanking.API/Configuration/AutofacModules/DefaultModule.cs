﻿using Autofac;
using OnlineBanking.BL;

 namespace OnlineBanking.API.Configuration.AutofacModules
{
    /// <summary>
    /// Default module for Autofac
    /// </summary>
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MockTransactionService>().As<ITransactionService>().SingleInstance();
        }
    }
}
