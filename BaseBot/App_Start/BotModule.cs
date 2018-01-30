﻿using Autofac;
using BaseBot.Dialogs;
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
            builder.RegisterType<RootDialog>();

            base.Load(builder);
        }
    }
}