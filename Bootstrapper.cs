using DamagoApiHelper.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using DamagoApiHelper.Services;

namespace DamagoApiHelper
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<ITextService, TextService>();
            containerRegistry.RegisterScoped<IAnalyzerService, AnalyzerService>();
            containerRegistry.RegisterScoped<IEndpointService, EndpointService>();
            containerRegistry.RegisterScoped<ITemplateService, TemplateService>();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellView>();
        }
    }
}
