using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DamagoApiHelper.Services;
using DamagoApiHelper.Views;
using Prism.Regions;

namespace DamagoApiHelper.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public ShellViewModel(ITextService textService, IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion<ConfigView>("MainRegion");
        }
    }
}
