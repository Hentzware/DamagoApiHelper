using System.Collections.Generic;
using DamagoApiHelper.Services;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Mvvm;

namespace DamagoApiHelper.ViewModels;

public class ConfigViewModel : BindableBase
{
    private readonly IProjectAnalyzerService _projectAnalyzerService;
    private DelegateCommand _projectPathSearchCommand;
    private string _projectPath;
    private List<string> _endpoints;

    public ConfigViewModel(IProjectAnalyzerService projectAnalyzerService)
    {
        _projectAnalyzerService = projectAnalyzerService;
    }

    public List<string> Endpoints
    {
        get => _endpoints;
        set => SetProperty(ref _endpoints, value);
    }

    public DelegateCommand ProjectPathSearchCommand =>
        _projectPathSearchCommand ?? new DelegateCommand(ExecuteProjectPathSearchCommand);

    public string ProjectPath
    {
        get => _projectPath;
        set => SetProperty(ref _projectPath, value);
    }

    private void ExecuteProjectPathSearchCommand()
    {
        var dialog = new CommonOpenFileDialog
        {
            IsFolderPicker = true
        };

        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            ProjectPath = dialog.FileName;
        }

        Endpoints = _projectAnalyzerService.GetEndpoints(ProjectPath);
    }
}