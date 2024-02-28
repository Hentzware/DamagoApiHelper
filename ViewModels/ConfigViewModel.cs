using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using DamagoApiHelper.Models;
using DamagoApiHelper.Services;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Mvvm;

namespace DamagoApiHelper.ViewModels;

public class ConfigViewModel : BindableBase
{
    private readonly Dictionary<string, string> replacementDictionary = new()
    {
        { "{{projectPath}}", "org.damago.damagodatenbankapi" },
        { "{{EntityName}}", "Entity" },
        { "{{EntityNames}}", "Entities" },
        { "{{entityName}}", "entity" },
        { "{{entityNames}}", "entities" }
    };

    private readonly IAnalyzerService _analyzerService;
    private readonly IEndpointService _endpointService;
    private bool _addRequestAddButtonEnabled;
    private bool _addRequestRemoveButtonEnabled;
    private bool _controllerAddButtonEnabled;
    private bool _controllerRemoveButtonEnabled;
    private bool _deleteRequestAddButtonEnabled;
    private bool _deleteRequestRemoveButtonEnabled;
    private bool _editRequestAddButtonEnabled;
    private bool _editRequestRemoveButtonEnabled;
    private bool _entityAddButtonEnabled;
    private bool _entityRemoveButtonEnabled;
    private bool _getRequestAddButtonEnabled;
    private bool _getRequestRemoveButtonEnabled;
    private bool _repositoryAddButtonEnabled;
    private bool _repositoryRemoveButtonEnabled;
    private bool _responseAddButtonEnabled;
    private bool _responseRemoveButtonEnabled;
    private bool _searchRequestAddButtonEnabled;
    private bool _searchRequestRemoveButtonEnabled;
    private bool _serviceAddButtonEnabled;
    private bool _serviceImplAddButtonEnabled;
    private bool _serviceImplRemoveButtonEnabled;
    private bool _serviceRemoveButtonEnabled;
    private DelegateCommand _projectPathSearchCommand;
    private DelegateCommand<string> _addCommand;
    private DelegateCommand<string> _removeCommand;
    private Endpoint? _selectedEndpoint;
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
    private string _addRequestStatus = "UNBEKANNT";
    private string _controllerStatus = "UNBEKANNT";
    private string _deleteRequestStatus = "UNBEKANNT";
    private string _editRequestStatus = "UNBEKANNT";
    private string _entityName;
    private string _getRequestStatus = "UNBEKANNT";
    private string _projectPath;
    private string _repositoryStatus = "UNBEKANNT";
    private string _responseStatus = "UNBEKANNT";
    private string _searchRequestStatus = "UNBEKANNT";
    private string _serviceInterfaceStatus = "UNBEKANNT";
    private string _serviceStatus = "UNBEKANNT";

    public ConfigViewModel(IAnalyzerService analyzerService, IEndpointService endpointService)
    {
        _analyzerService = analyzerService;
        _endpointService = endpointService;
    }

    public bool AddRequestAddButtonEnabled
    {
        get => !_selectedEndpoint?.AddRequestFileExists ?? false;
        set => SetProperty(ref _addRequestAddButtonEnabled, value);
    }

    public bool AddRequestRemoveButtonEnabled
    {
        get => _selectedEndpoint?.AddRequestFileExists ?? false;
        set => SetProperty(ref _addRequestRemoveButtonEnabled, value);
    }

    public bool ControllerAddButtonEnabled
    {
        get => !_selectedEndpoint?.ControllerFileExists ?? false;
        set => SetProperty(ref _controllerAddButtonEnabled, value);
    }

    public bool ControllerRemoveButtonEnabled
    {
        get => _selectedEndpoint?.ControllerFileExists ?? false;
        set => SetProperty(ref _controllerRemoveButtonEnabled, value);
    }

    public bool DeleteRequestAddButtonEnabled
    {
        get => !_selectedEndpoint?.DeleteRequestFileExists ?? false;
        set => SetProperty(ref _deleteRequestAddButtonEnabled, value);
    }

    public bool DeleteRequestRemoveButtonEnabled
    {
        get => _selectedEndpoint?.DeleteRequestFileExists ?? false;
        set => SetProperty(ref _deleteRequestRemoveButtonEnabled, value);
    }

    public bool EditRequestAddButtonEnabled
    {
        get => !_selectedEndpoint?.EditRequestFileExists ?? false;
        set => SetProperty(ref _editRequestAddButtonEnabled, value);
    }

    public bool EditRequestRemoveButtonEnabled
    {
        get => _selectedEndpoint?.EditRequestFileExists ?? false;
        set => SetProperty(ref _editRequestRemoveButtonEnabled, value);
    }

    public bool EntityAddButtonEnabled
    {
        get => !string.IsNullOrEmpty(EntityName);
        set => SetProperty(ref _entityAddButtonEnabled, value);
    }

    public bool EntityRemoveButtonEnabled
    {
        get => _selectedEndpoint != null;
        set => SetProperty(ref _entityRemoveButtonEnabled, value);
    }

    public bool GetRequestAddButtonEnabled
    {
        get => !_selectedEndpoint?.GetRequestFileExists ?? false;
        set => SetProperty(ref _getRequestAddButtonEnabled, value);
    }

    public bool GetRequestRemoveButtonEnabled
    {
        get => _selectedEndpoint?.GetRequestFileExists ?? false;
        set => SetProperty(ref _getRequestRemoveButtonEnabled, value);
    }

    public bool RepositoryAddButtonEnabled
    {
        get => !_selectedEndpoint?.RepositoryFileExists ?? false;
        set => SetProperty(ref _repositoryAddButtonEnabled, value);
    }

    public bool RepositoryRemoveButtonEnabled
    {
        get => _selectedEndpoint?.RepositoryFileExists ?? false;
        set => SetProperty(ref _repositoryRemoveButtonEnabled, value);
    }

    public bool ResponseAddButtonEnabled
    {
        get => !_selectedEndpoint?.ResponseFileExists ?? false;
        set => SetProperty(ref _responseAddButtonEnabled, value);
    }

    public bool ResponseRemoveButtonEnabled
    {
        get => _selectedEndpoint?.ResponseFileExists ?? false;
        set => SetProperty(ref _responseRemoveButtonEnabled, value);
    }

    public bool SearchRequestAddButtonEnabled
    {
        get => !_selectedEndpoint?.SearchRequestFileExists ?? false;
        set => SetProperty(ref _searchRequestAddButtonEnabled, value);
    }

    public bool SearchRequestRemoveButtonEnabled
    {
        get => _selectedEndpoint?.SearchRequestFileExists ?? false;
        set => SetProperty(ref _searchRequestRemoveButtonEnabled, value);
    }

    public bool ServiceAddButtonEnabled
    {
        get => !_selectedEndpoint?.ServiceFileExists ?? false;
        set => SetProperty(ref _serviceAddButtonEnabled, value);
    }

    public bool ServiceImplAddButtonEnabled
    {
        get => !_selectedEndpoint?.ServiceImplFileExists ?? false;
        set => SetProperty(ref _serviceImplAddButtonEnabled, value);
    }

    public bool ServiceImplRemoveButtonEnabled
    {
        get => _selectedEndpoint?.ServiceImplFileExists ?? false;
        set => SetProperty(ref _serviceImplRemoveButtonEnabled, value);
    }

    public bool ServiceRemoveButtonEnabled
    {
        get => _selectedEndpoint?.ServiceFileExists ?? false;
        set => SetProperty(ref _serviceRemoveButtonEnabled, value);
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
                InitializeEndpointStatus(value);
            }
            
            RaisePropertyChanged(nameof(EntityRemoveButtonEnabled));
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

    public string EntityName
    {
        get => _entityName;
        set
        {
            SetProperty(ref _entityName, value);
            RaisePropertyChanged(nameof(EntityAddButtonEnabled));
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

    public string ProjectPath
    {
        get => _projectPath;
        set => SetProperty(ref _projectPath, value);
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

    private SolidColorBrush GetStatusColor(string status)
    {
        if (status == "OK")
        {
            return new SolidColorBrush(Colors.Green);
        }

        return new SolidColorBrush(Colors.Red);
    }

    private void ExecuteAddCommand(string obj)
    {
        switch (obj)
        {
            case "Entity":
                var endpoint = new Endpoint()
                {
                    ProjectPath = ProjectPath,
                    EntityFilePath = $"{ProjectPath}\\entities\\{EntityName}.java"
                };
                _endpointService.AddEntity(endpoint, replacementDictionary);
                Endpoints.Add(endpoint);
                RaisePropertyChanged(nameof(Endpoints));
                SelectedEndpoint = endpoint;
                break;
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
        }
    }

    private void InitializeEndpointStatus(Endpoint endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

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

        RefreshButtonStatus();
    }

    private void RefreshButtonStatus()
    {
        RaisePropertyChanged(nameof(ControllerAddButtonEnabled));
        RaisePropertyChanged(nameof(ControllerRemoveButtonEnabled));
        RaisePropertyChanged(nameof(RepositoryAddButtonEnabled));
        RaisePropertyChanged(nameof(RepositoryRemoveButtonEnabled));
        RaisePropertyChanged(nameof(ResponseAddButtonEnabled));
        RaisePropertyChanged(nameof(ResponseRemoveButtonEnabled));
        RaisePropertyChanged(nameof(AddRequestAddButtonEnabled));
        RaisePropertyChanged(nameof(AddRequestRemoveButtonEnabled));
        RaisePropertyChanged(nameof(EditRequestAddButtonEnabled));
        RaisePropertyChanged(nameof(EditRequestRemoveButtonEnabled));
        RaisePropertyChanged(nameof(DeleteRequestAddButtonEnabled));
        RaisePropertyChanged(nameof(DeleteRequestRemoveButtonEnabled));
        RaisePropertyChanged(nameof(GetRequestAddButtonEnabled));
        RaisePropertyChanged(nameof(GetRequestRemoveButtonEnabled));
        RaisePropertyChanged(nameof(SearchRequestAddButtonEnabled));
        RaisePropertyChanged(nameof(SearchRequestRemoveButtonEnabled));
        RaisePropertyChanged(nameof(ServiceAddButtonEnabled));
        RaisePropertyChanged(nameof(ServiceRemoveButtonEnabled));
        RaisePropertyChanged(nameof(ServiceImplAddButtonEnabled));
        RaisePropertyChanged(nameof(ServiceImplRemoveButtonEnabled));
    }
}