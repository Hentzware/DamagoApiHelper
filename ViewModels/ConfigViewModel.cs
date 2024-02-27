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
    private readonly IEndpointService _endpointService;
    private readonly IProjectAnalyzerService _projectAnalyzerService;
    private bool _addRequestStatus;
    private bool _controllerStatus;
    private bool _deleteRequestStatus;
    private bool _editRequestStatus;
    private bool _getRequestStatus;
    private bool _repositoryStatus;
    private bool _responseStatus;
    private bool _searchRequestStatus;
    private bool _serviceInterfaceStatus;
    private bool _serviceStatus;
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

    public ConfigViewModel(IProjectAnalyzerService projectAnalyzerService, ITextReplaceService textReplaceService)
    {
        _projectAnalyzerService = projectAnalyzerService;
        _endpointService = new EndpointService(textReplaceService, SelectedEndpoint);
    }

    public bool AddRequestStatus
    {
        get => _addRequestStatus;
        set
        {
            SetProperty(ref _addRequestStatus, value);
            AddRequestStatusColor = GetStatusColor(value);
        }
    }

    public bool ControllerStatus
    {
        get => _controllerStatus;
        set
        {
            SetProperty(ref _controllerStatus, value);
            ControllerStatusColor = GetStatusColor(value);
        }
    }

    public bool DeleteRequestStatus
    {
        get => _deleteRequestStatus;
        set
        {
            SetProperty(ref _deleteRequestStatus, value);
            DeleteRequestStatusColor = GetStatusColor(value);
        }
    }

    public bool EditRequestStatus
    {
        get => _editRequestStatus;
        set
        {
            SetProperty(ref _editRequestStatus, value);
            EditRequestStatusColor = GetStatusColor(value);
        }
    }

    public bool GetRequestStatus
    {
        get => _getRequestStatus;
        set
        {
            SetProperty(ref _getRequestStatus, value);
            GetRequestStatusColor = GetStatusColor(value);
        }
    }

    public bool RepositoryStatus
    {
        get => _repositoryStatus;
        set
        {
            SetProperty(ref _repositoryStatus, value);
            RepositoryStatusColor = GetStatusColor(value);
        }
    }

    public bool ResponseStatus
    {
        get => _responseStatus;
        set
        {
            SetProperty(ref _responseStatus, value);
            ResponseStatusColor = GetStatusColor(value);
        }
    }

    public bool SearchRequestStatus
    {
        get => _searchRequestStatus;
        set
        {
            SetProperty(ref _searchRequestStatus, value);
            SearchRequestStatusColor = GetStatusColor(value);
        }
    }

    public bool ServiceInterfaceStatus
    {
        get => _serviceInterfaceStatus;
        set
        {
            SetProperty(ref _serviceInterfaceStatus, value);
            ServiceInterfaceStatusColor = GetStatusColor(value);
        }
    }

    public bool ServiceStatus
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

    private SolidColorBrush GetStatusColor(bool status)
    {
        if (status)
        {
            return new SolidColorBrush(Colors.Green);
        }

        return new SolidColorBrush(Colors.Red);
    }

    private void ExecuteAddCommand(string obj)
    {
        switch (obj)
        {
            case "Controller":
                _endpointService.AddController();
                break;
            case "AddRequest":
                _endpointService.AddAddRequest();
                break;
            case "EditRequest":
                _endpointService.AddEditRequest();
                break;
            case "DeleteRequest":
                _endpointService.AddDeleteRequest();
                break;
            case "GetRequest":
                _endpointService.AddGetRequest();
                break;
            case "SearchRequest":
                _endpointService.AddSearchRequest();
                break;
            case "Response":
                _endpointService.AddResponse();
                break;
            case "Service":
                _endpointService.AddService();
                break;
            case "ServiceImpl":
                _endpointService.AddServiceImpl();
                break;
            case "Repository":
                _endpointService.AddRepository();
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

        Endpoints = _projectAnalyzerService.GetEndpoints(ProjectPath);
    }

    private void ExecuteRemoveCommand(string obj)
    {
        switch (obj)
        {
            case "Controller":
                _endpointService.RemoveController();
                break;
            case "AddRequest":
                _endpointService.RemoveAddRequest();
                break;
            case "EditRequest":
                _endpointService.RemoveEditRequest();
                break;
            case "DeleteRequest":
                _endpointService.RemoveDeleteRequest();
                break;
            case "GetRequest":
                _endpointService.RemoveGetRequest();
                break;
            case "SearchRequest":
                _endpointService.RemoveSearchRequest();
                break;
            case "Response":
                _endpointService.RemoveResponse();
                break;
            case "Service":
                _endpointService.RemoveService();
                break;
            case "ServiceImpl":
                _endpointService.RemoveServiceImpl();
                break;
            case "Repository":
                _endpointService.RemoveRepository();
                break;
        }
    }

    private void InitializeEndpointStatus(Endpoint endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        ControllerStatus = endpoint.ControllerFileExists;
        RepositoryStatus = endpoint.RepositoryFileExists;
        ServiceInterfaceStatus = endpoint.ServiceImplFileExists;
        ServiceStatus = endpoint.ServiceFileExists;
        AddRequestStatus = endpoint.AddRequestFileExists;
        GetRequestStatus = endpoint.GetRequestFileExists;
        EditRequestStatus = endpoint.EditRequestFileExists;
        DeleteRequestStatus = endpoint.DeleteRequestFileExists;
        SearchRequestStatus = endpoint.SearchRequestFileExists;
        ResponseStatus = endpoint.ResponseFileExists;
    }
}