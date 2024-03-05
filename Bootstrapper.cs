using System.Windows;
using DamagoApiHelper.Services;
using DamagoApiHelper.Views;
using Prism.DryIoc;
using Prism.Ioc;

namespace DamagoApiHelper;

public class Bootstrapper : PrismBootstrapper
{
    protected override DependencyObject CreateShell()
    {
        return Container.Resolve<ShellView>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterScoped<IEndpointService, EndpointService>();
    }
}