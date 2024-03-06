using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using DamagoApiHelper.Models;
using DamagoApiHelper.Services;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Mvvm;

namespace DamagoApiHelper.ViewModels;

public class ConfigViewModel : BindableBase
{
    private readonly IEndpointService _endpointService;
    private bool _entityAddButtonEnabled;
    private bool _entityRemoveButtonEnabled;
    private DelegateCommand _projectPathSearchCommand;
    private DelegateCommand<string> _addCommand;
    private DelegateCommand<string> _removeCommand;
    private Endpoint? _selectedEndpoint;
    private ObservableCollection<Endpoint> _endpoints;
    private string _entityName;
    private string _entityNamePlural;
    private string _projectPath;

    public ConfigViewModel(IEndpointService endpointService)
    {
        _endpointService = endpointService;
    }

    public bool EntityAddButtonEnabled
    {
        get =>
            !string.IsNullOrEmpty(EntityName) &&
            !string.IsNullOrEmpty(ProjectPath) &&
            !string.IsNullOrEmpty(EntityNamePlural);
        set => SetProperty(ref _entityAddButtonEnabled, value);
    }

    public bool EntityRemoveButtonEnabled
    {
        get => _selectedEndpoint != null;
        set => SetProperty(ref _entityRemoveButtonEnabled, value);
    }

    public DelegateCommand ProjectPathSearchCommand =>
        _projectPathSearchCommand ?? new DelegateCommand(ExecuteProjectPathSearchCommand);

    public DelegateCommand<string> AddCommand =>
        _addCommand ?? new DelegateCommand<string>(ExecuteAddCommand);

    public DelegateCommand<string> RemoveCommand =>
        _removeCommand ?? new DelegateCommand<string>(ExecuteRemoveCommand);

    public Endpoint? SelectedEndpoint
    {
        get => _selectedEndpoint;
        set
        {
            SetProperty(ref _selectedEndpoint, value);

            if (value != null)
            {
                EntityName = value.EntityName;
            }

            RaisePropertyChanged(nameof(EntityRemoveButtonEnabled));
        }
    }

    public ObservableCollection<Endpoint> Endpoints
    {
        get => _endpoints;
        set => SetProperty(ref _endpoints, value);
    }

    public string EntityName
    {
        get => _entityName;
        set
        {
            SetProperty(ref _entityName, value);
            RaisePropertyChanged(nameof(EntityAddButtonEnabled));
        }
    }

    public string EntityNamePlural
    {
        get => _entityNamePlural;
        set => SetProperty(ref _entityNamePlural, value);
    }

    public string EntityNamePluralLowerCase => !string.IsNullOrEmpty(EntityNamePlural) ? char.ToLower(EntityNamePlural[0]) + EntityNamePlural.Substring(1) : EntityName + "s";

    public string ProjectPath
    {
        get => _projectPath;
        set => SetProperty(ref _projectPath, value);
    }

    private Dictionary<string, string> GetReplacementDictionary(Endpoint endpoint)
    {
        return new Dictionary<string, string>
        {
            { "{{projectPath}}", endpoint.PackageName },
            { "{{EntityName}}", endpoint.EntityName },
            { "{{EntityNames}}", EntityNamePlural },
            { "{{entityName}}", endpoint.EntityNameLowerCase },
            { "{{entityNames}}", EntityNamePluralLowerCase }
        };
    }

    private void ExecuteAddCommand(string templateFile)
    {
        var tmp = SelectedEndpoint;

        switch (templateFile)
        {
            case "Entity":
                var endpoint = new Endpoint
                {
                    ProjectPath = ProjectPath,
                    EntityName = EntityName
                };
                _endpointService.Add(templateFile, endpoint.EntityFilePath, GetReplacementDictionary(endpoint));
                Endpoints.Add(endpoint);
                tmp = endpoint;
                break;
            case "Controller":
                _endpointService.Add(templateFile, SelectedEndpoint.ControllerFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "AddRequest":
                _endpointService.Add(templateFile, SelectedEndpoint.AddRequestFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "EditRequest":
                _endpointService.Add(templateFile, SelectedEndpoint.EditRequestFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "DeleteRequest":
                _endpointService.Add(templateFile, SelectedEndpoint.DeleteRequestFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "GetRequest":
                _endpointService.Add(templateFile, SelectedEndpoint.GetRequestFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SearchRequest":
                _endpointService.Add(templateFile, SelectedEndpoint.SearchRequestFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "Response":
                _endpointService.Add(templateFile, SelectedEndpoint.ResponseFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "Service":
                _endpointService.Add(templateFile, SelectedEndpoint.ServiceFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "ServiceImpl":
                _endpointService.Add(templateFile, SelectedEndpoint.ServiceImplFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "Repository":
                _endpointService.Add(templateFile, SelectedEndpoint.RepositoryFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpAdd":
                _endpointService.Add(templateFile, SelectedEndpoint.SpAddFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpDelete":
                _endpointService.Add(templateFile, SelectedEndpoint.SpDeleteFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpDeletePermanent":
                _endpointService.Add(templateFile, SelectedEndpoint.SpDeletePermanentFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpGet":
                _endpointService.Add(templateFile, SelectedEndpoint.SpGetFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpGetById":
                _endpointService.Add(templateFile, SelectedEndpoint.SpGetByIdFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpGetDeleted":
                _endpointService.Add(templateFile, SelectedEndpoint.SpGetDeletedFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpSearch":
                _endpointService.Add(templateFile, SelectedEndpoint.SpSearchFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpUndelete":
                _endpointService.Add(templateFile, SelectedEndpoint.SpUndeleteFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SpUpdate":
                _endpointService.Add(templateFile, SelectedEndpoint.SpUpdateFilePath, GetReplacementDictionary(SelectedEndpoint));
                break;
        }

        Endpoints = new ObservableCollection<Endpoint>(_endpointService.GetEndpoints(ProjectPath));
        SelectedEndpoint = Endpoints.FirstOrDefault(x => x.EntityFileName == tmp.EntityFileName);
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

        Endpoints = _endpointService.GetEndpoints(ProjectPath);
    }

    private void ExecuteRemoveCommand(string templateFile)
    {
        switch (templateFile)
        {
            case "Entity":
                _endpointService.Remove(SelectedEndpoint.EntityFilePath, false);
                break;
            case "Controller":
                _endpointService.Remove(SelectedEndpoint.ControllerFilePath, false);
                break;
            case "AddRequest":
                _endpointService.Remove(SelectedEndpoint.AddRequestFilePath, true);
                break;
            case "EditRequest":
                _endpointService.Remove(SelectedEndpoint.EditRequestFilePath, true);
                break;
            case "DeleteRequest":
                _endpointService.Remove(SelectedEndpoint.DeleteRequestFilePath, true);
                break;
            case "GetRequest":
                _endpointService.Remove(SelectedEndpoint.GetRequestFilePath, true);
                break;
            case "SearchRequest":
                _endpointService.Remove(SelectedEndpoint.SearchRequestFilePath, true);
                break;
            case "Response":
                _endpointService.Remove(SelectedEndpoint.ResponseFilePath, false);
                break;
            case "Service":
                _endpointService.Remove(SelectedEndpoint.ServiceFilePath, false);
                break;
            case "ServiceImpl":
                _endpointService.Remove(SelectedEndpoint.ServiceImplFilePath, false);
                break;
            case "Repository":
                _endpointService.Remove(SelectedEndpoint.RepositoryFilePath, false);
                break;
            case "SpAdd":
                break;
            case "SpDelete":
                break;
            case "SpDeletePermanent":
                break;
            case "SpGet":
                break;
            case "SpGetById":
                break;
            case "SpGetDeleted":
                break;
            case "SpSearch":
                break;
            case "SpUndelete":
                break;
            case "SpUpdate":
                break;
        }

        var tmp = SelectedEndpoint;
        Endpoints = new ObservableCollection<Endpoint>(_endpointService.GetEndpoints(ProjectPath));
        SelectedEndpoint = Endpoints.FirstOrDefault(x => x.EntityFileName == tmp.EntityFileName);
    }
}