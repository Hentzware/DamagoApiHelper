using DamagoApiHelper.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DamagoApiHelper.Services;

namespace DamagoApiHelper
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<ITextReplaceService, TextReplaceService>();
            containerRegistry.RegisterScoped<IProjectAnalyzerService, ProjectAnalyzerService>();
            containerRegistry.RegisterScoped<IEndpointService, EndpointService>();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellView>();
        }
    }
}
