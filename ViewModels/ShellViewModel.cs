using DamagoApiHelper.Services;
using DamagoApiHelper.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace DamagoApiHelper.ViewModels;

public class ShellViewModel : BindableBase
{
    public ShellViewModel(ITextService textService, IRegionManager regionManager)
    {
        regionManager.RegisterViewWithRegion<ConfigView>("MainRegion");
    }
}