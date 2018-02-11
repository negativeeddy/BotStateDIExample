using Autofac;
using BaseBot.Dialogs;
using BaseBot.Services;
using Microsoft.Bot.Builder.Dialogs;
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
            // register the root dialog
            builder.RegisterType<RootDialog>()
                .As<IDialog<object>>()
                .InstancePerDependency();

            // Alternative method to globally register the root dialog creation
            // method. If the root dialog is always the same, this can be used instead
            // of the 'makeRoot' code in MessagesController
            //
            // builder.Register<Func<IDialog<object>>>(c =>
            // {
            //     var dlg = c.Resolve<IDialog<object>>();
            //     Func<IDialog<object>> makeRoot = () => dlg;
            //     return makeRoot;
            // });

            // register the class which stores properties in the bot state data store
            builder.RegisterType<UserData>()
                .Keyed<IUserData>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}