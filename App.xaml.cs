﻿using System.Windows;

namespace DamagoApiHelper;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var bootstrapper = new Bootstrapper();

        bootstrapper.Run();

        base.OnStartup(e);
    }
}