using Autofac;
using BaseBot.Dialogs;
using BaseBot.Services;
using Microsoft.Bot.Builder.Internals.Fibers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseBot.App_Start
{
    public class BotModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RootDialog>()
                .InstancePerDependency();

            builder.RegisterType<UserData>()
                .Keyed<IUserData>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}