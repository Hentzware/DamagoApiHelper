using System.Collections.Generic;
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
    private string _addRequestStatus = "UNBEKANNT";
    private string _controllerStatus = "UNBEKANNT";
    private string _deleteRequestStatus = "UNBEKANNT";
    private string _editRequestStatus = "UNBEKANNT";
    private string _getRequestStatus = "UNBEKANNT";
    private string _repositoryStatus = "UNBEKANNT";
    private string _responseStatus = "UNBEKANNT";
    private string _searchRequestStatus = "UNBEKANNT";
    private string _serviceInterfaceStatus = "UNBEKANNT";
    private string _serviceStatus = "UNBEKANNT";
    private DelegateCommand _projectPathSearchCommand;
    private DelegateCommand<string> _addCommand;
    private DelegateCommand<string> _removeCommand;
    private Endpoint _selectedEndpoint;
    private List<Endpoint> _endpoints;
    private SolidColorBrush _addRequestStatusColor = new(Colors.Gray);
    private SolidColorBrush _controllerStatusColor = new(Colors.Gray);
    private SolidColorBrush _deleteRequestStatusColor = new(Colors.Gray);
    private SolidColorBrush _editRequestStatusColor = new(Colors.Gray);
    private SolidColorBrush _getRequestStatusColor = new(Colors.Gray);
    private SolidColorBrush _repositoryStatusColor = new(Colors.Gray);
    private SolidColorBrush _responseStatusColor = new(Colors.Gray);
    private SolidColorBrush _searchRequestStatusColor = new(Colors.Gray);
    private SolidColorBrush _serviceInterfaceStatusColor = new(Colors.Gray);
    private SolidColorBrush _serviceStatusColor = new(Colors.Gray);
    private string _projectPath;

    private Dictionary<string, string> replacementDictionary = new Dictionary<string, string>()
    {
        {"{{projectPath}}", "org.damago.damagodatenbankapi"},
        {"{{EntityName}}", "Entity"},
        {"{{EntityNames}}", "Entities"},
        {"{{entityName}}", "entity"},
        {"{{entityNames}}", "entities"}
    };

    public ConfigViewModel(IAnalyzerService analyzerService, IEndpointService endpointService)
    {
        _analyzerService = analyzerService;
        _endpointService = endpointService;
    }

    public string AddRequestStatus
    {
        get => _addRequestStatus;
        set
        {
            SetProperty(ref _addRequestStatus, value);
            AddRequestStatusColor = GetStatusColor(value);
        }
    }

    public string ControllerStatus
    {
        get => _controllerStatus;
        set
        {
            SetProperty(ref _controllerStatus, value);
            ControllerStatusColor = GetStatusColor(value);
        }
    }

    public string DeleteRequestStatus
    {
        get => _deleteRequestStatus;
        set
        {
            SetProperty(ref _deleteRequestStatus, value);
            DeleteRequestStatusColor = GetStatusColor(value);
        }
    }

    public string EditRequestStatus
    {
        get => _editRequestStatus;
        set
        {
            SetProperty(ref _editRequestStatus, value);
            EditRequestStatusColor = GetStatusColor(value);
        }
    }

    public string GetRequestStatus
    {
        get => _getRequestStatus;
        set
        {
            SetProperty(ref _getRequestStatus, value);
            GetRequestStatusColor = GetStatusColor(value);
        }
    }

    public string RepositoryStatus
    {
        get => _repositoryStatus;
        set
        {
            SetProperty(ref _repositoryStatus, value);
            RepositoryStatusColor = GetStatusColor(value);
        }
    }

    public string ResponseStatus
    {
        get => _responseStatus;
        set
        {
            SetProperty(ref _responseStatus, value);
            ResponseStatusColor = GetStatusColor(value);
        }
    }

    public string SearchRequestStatus
    {
        get => _searchRequestStatus;
        set
        {
            SetProperty(ref _searchRequestStatus, value);
            SearchRequestStatusColor = GetStatusColor(value);
        }
    }

    public string ServiceInterfaceStatus
    {
        get => _serviceInterfaceStatus;
        set
        {
            SetProperty(ref _serviceInterfaceStatus, value);
            ServiceInterfaceStatusColor = GetStatusColor(value);
        }
    }

    public string ServiceStatus
    {
        get => _serviceStatus;
        set
        {
            SetProperty(ref _serviceStatus, value);
            ServiceStatusColor = GetStatusColor(value);
        }
    }

    public DelegateCommand ProjectPathSearchCommand =>
        _projectPathSearchCommand ?? new DelegateCommand(ExecuteProjectPathSearchCommand);

    public DelegateCommand<string> AddCommand =>
        _addCommand ?? new DelegateCommand<string>(ExecuteAddCommand);

    public DelegateCommand<string> RemoveCommand =>
        _removeCommand ?? new DelegateCommand<string>(ExecuteRemoveCommand);

    public Endpoint SelectedEndpoint
    {
        get => _selectedEndpoint;
        set
        {
            SetProperty(ref _selectedEndpoint, value);
            InitializeEndpointStatus(value);
        }
    }

    public List<Endpoint> Endpoints
    {
        get => _endpoints;
        set => SetProperty(ref _endpoints, value);
    }

    public SolidColorBrush AddRequestStatusColor
    {
        get => _addRequestStatusColor;
        set => SetProperty(ref _addRequestStatusColor, value);
    }

    public SolidColorBrush ControllerStatusColor
    {
        get => _controllerStatusColor;
        set => SetProperty(ref _controllerStatusColor, value);
    }

    public SolidColorBrush DeleteRequestStatusColor
    {
        get => _deleteRequestStatusColor;
        set => SetProperty(ref _deleteRequestStatusColor, value);
    }

    public SolidColorBrush EditRequestStatusColor
    {
        get => _editRequestStatusColor;
        set => SetProperty(ref _editRequestStatusColor, value);
    }

    public SolidColorBrush GetRequestStatusColor
    {
        get => _getRequestStatusColor;
        set => SetProperty(ref _getRequestStatusColor, value);
    }

    public SolidColorBrush RepositoryStatusColor
    {
        get => _repositoryStatusColor;
        set => SetProperty(ref _repositoryStatusColor, value);
    }

    public SolidColorBrush ResponseStatusColor
    {
        get => _responseStatusColor;
        set => SetProperty(ref _responseStatusColor, value);
    }

    public SolidColorBrush SearchRequestStatusColor
    {
        get => _searchRequestStatusColor;
        set => SetProperty(ref _searchRequestStatusColor, value);
    }

    public SolidColorBrush ServiceInterfaceStatusColor
    {
        get => _serviceInterfaceStatusColor;
        set => SetProperty(ref _serviceInterfaceStatusColor, value);
    }

    public SolidColorBrush ServiceStatusColor
    {
        get => _serviceStatusColor;
        set => SetProperty(ref _serviceStatusColor, value);
    }

    public string ProjectPath
    {
        get => _projectPath;
        set => SetProperty(ref _projectPath, value);
    }

    private SolidColorBrush GetStatusColor(string status)
    {
        if (status == "OK") return new SolidColorBrush(Colors.Green);

        return new SolidColorBrush(Colors.Red);
    }

    private void ExecuteAddCommand(string obj)
    {
        switch (obj)
        {
            case "Controller":
                _endpointService.AddController(SelectedEndpoint, replacementDictionary);
                break;
            case "AddRequest":
                _endpointService.AddAddRequest(SelectedEndpoint, replacementDictionary);
                break;
            case "EditRequest":
                _endpointService.AddEditRequest(SelectedEndpoint, replacementDictionary);
                break;
            case "DeleteRequest":
                _endpointService.AddDeleteRequest(SelectedEndpoint, replacementDictionary);
                break;
            case "GetRequest":
                _endpointService.AddGetRequest(SelectedEndpoint, replacementDictionary);
                break;
            case "SearchRequest":
                _endpointService.AddSearchRequest(SelectedEndpoint, replacementDictionary);
                break;
            case "Response":
                _endpointService.AddResponse(SelectedEndpoint, replacementDictionary);
                break;
            case "Service":
                _endpointService.AddService(SelectedEndpoint, replacementDictionary);
                break;
            case "ServiceImpl":
                _endpointService.AddServiceImpl(SelectedEndpoint, replacementDictionary);
                break;
            case "Repository":
                _endpointService.AddRepository(SelectedEndpoint, replacementDictionary);
                break;
        }
    }

    private void ExecuteProjectPathSearchCommand()
    {
        var dialog = new CommonOpenFileDialog
        {
            IsFolderPicker = true
        };

        if (dialog.ShowDialog() == CommonFileDialogResult.Ok) ProjectPath = dialog.FileName;

        Endpoints = _analyzerService.GetEndpoints(ProjectPath);
    }

    private void ExecuteRemoveCommand(string obj)
    {
        switch (obj)
        {
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
        }
    }

    private void InitializeEndpointStatus(Endpoint endpoint)
    {
        if (endpoint == null) return;

        ControllerStatus = endpoint.ControllerFileExists ? "OK" : "FEHLT";
        RepositoryStatus = endpoint.RepositoryFileExists ? "OK" : "FEHLT";
        ServiceInterfaceStatus = endpoint.ServiceImplFileExists ? "OK" : "FEHLT";
        ServiceStatus = endpoint.ServiceFileExists ? "OK" : "FEHLT";
        AddRequestStatus = endpoint.AddRequestFileExists ? "OK" : "FEHLT";
        GetRequestStatus = endpoint.GetRequestFileExists ? "OK" : "FEHLT";
        EditRequestStatus = endpoint.EditRequestFileExists ? "OK" : "FEHLT";
        DeleteRequestStatus = endpoint.DeleteRequestFileExists ? "OK" : "FEHLT";
        SearchRequestStatus = endpoint.SearchRequestFileExists ? "OK" : "FEHLT";
        ResponseStatus = endpoint.ResponseFileExists ? "OK" : "FEHLT";
    }
}