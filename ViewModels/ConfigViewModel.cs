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
    private readonly IAnalyzerService _analyzerService;
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

    public ConfigViewModel(IAnalyzerService analyzerService, IEndpointService endpointService)
    {
        _analyzerService = analyzerService;
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
                EntityName = value.EntityFileName;
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

    public string EntityNamePluralLowerCase => char.ToLower(EntityNamePlural[0]) + EntityNamePlural.Substring(1);

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
            { "{{EntityName}}", endpoint.EntityFileName },
            { "{{EntityNames}}", EntityNamePlural },
            { "{{entityName}}", endpoint.EntityFileNameLowerCase },
            { "{{entityNames}}", EntityNamePluralLowerCase }
        };
    }

    private void ExecuteAddCommand(string obj)
    {
        var tmp = SelectedEndpoint;

        switch (obj)
        {
            case "Entity":
                var endpoint = new Endpoint
                {
                    ProjectPath = ProjectPath,
                    EntityFilePath = $"{ProjectPath}\\entities\\{EntityName}.java"
                };
                _endpointService.AddEntity(endpoint, GetReplacementDictionary(endpoint));
                Endpoints.Add(endpoint);
                tmp = endpoint;
                break;
            case "Controller":
                _endpointService.AddController(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "AddRequest":
                _endpointService.AddAddRequest(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "EditRequest":
                _endpointService.AddEditRequest(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "DeleteRequest":
                _endpointService.AddDeleteRequest(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "GetRequest":
                _endpointService.AddGetRequest(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "SearchRequest":
                _endpointService.AddSearchRequest(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "Response":
                _endpointService.AddResponse(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "Service":
                _endpointService.AddService(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "ServiceImpl":
                _endpointService.AddServiceImpl(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
                break;
            case "Repository":
                _endpointService.AddRepository(SelectedEndpoint, GetReplacementDictionary(SelectedEndpoint));
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

        Endpoints = new ObservableCollection<Endpoint>(_analyzerService.GetEndpoints(ProjectPath));
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

        Endpoints = _analyzerService.GetEndpoints(ProjectPath);
    }

    private void ExecuteRemoveCommand(string obj)
    {
        switch (obj)
        {
            case "Entity":
                _endpointService.RemoveEntity(SelectedEndpoint);
                break;
            case "Controller":
                _endpointService.RemoveController(SelectedEndpoint);
                break;
            case "AddRequest":
                _endpointService.RemoveAddRequest(SelectedEndpoint);
                break;
            case "EditRequest":
                _endpointService.RemoveEditRequest(SelectedEndpoint);
                break;
            case "DeleteRequest":
                _endpointService.RemoveDeleteRequest(SelectedEndpoint);
                break;
            case "GetRequest":
                _endpointService.RemoveGetRequest(SelectedEndpoint);
                break;
            case "SearchRequest":
                _endpointService.RemoveSearchRequest(SelectedEndpoint);
                break;
            case "Response":
                _endpointService.RemoveResponse(SelectedEndpoint);
                break;
            case "Service":
                _endpointService.RemoveService(SelectedEndpoint);
                break;
            case "ServiceImpl":
                _endpointService.RemoveServiceImpl(SelectedEndpoint);
                break;
            case "Repository":
                _endpointService.RemoveRepository(SelectedEndpoint);
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
        Endpoints = new ObservableCollection<Endpoint>(_analyzerService.GetEndpoints(ProjectPath));
        SelectedEndpoint = Endpoints.FirstOrDefault(x => x.EntityFileName == tmp.EntityFileName);
    }
}