﻿namespace TfsBuildExtensions.Activities.TeamFoundationServer
{
    using System;
    using System.Activities;
    using System.ComponentModel;
    using Microsoft.TeamFoundation.Build.Client;
    using Microsoft.TeamFoundation.Client;

    [BuildActivity(HostEnvironmentOption.All)]
    public sealed class GetBuildAgentMachineName : CodeActivity
    {
        [RequiredArgument]
        [Browsable(true)]
        public InArgument<IBuildAgent> BuildAgent { get; set; }

        [RequiredArgument]
        [Browsable(true)]
        public OutArgument<String> AgentMachineName { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            IBuildAgent buildAgent = context.GetValue(this.BuildAgent);
            context.SetValue(this.AgentMachineName, buildAgent.Url.Host);
        }
    }
}