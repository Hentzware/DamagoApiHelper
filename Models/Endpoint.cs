using System.Windows.Media;

namespace DamagoApiHelper.Models;

public class Endpoint
{
    private readonly SolidColorBrush _colorGreen = new(Colors.Green);
    
    private readonly SolidColorBrush _colorRed = new(Colors.Red);
    
    public string SpAddFilePath { get; set; }
    
    public string SpDeleteFilePath { get; set; }
    
    public string SpDeletePermanentFilePath { get; set; }
    
    public string SpGetFilePath { get; set; }
    
    public string SpGetByIdFilePath { get; set; }
    
    public string SpGetDeletedFilePath { get; set; }
    
    public string SpSearchFilePath { get; set; }

    public bool AddRequestAddButtonEnabled => !AddRequestFileExists;

    public bool AddRequestFileExists => !string.IsNullOrEmpty(AddRequestFilePath);

    public bool AddRequestRemoveButtonEnabled => AddRequestFileExists;

    public bool ControllerAddButtonEnabled => !ControllerFileExists;

    public bool ControllerFileExists => !string.IsNullOrEmpty(ControllerFilePath);

    public bool ControllerRemoveButtonEnabled => ControllerFileExists;

    public bool DeleteRequestAddButtonEnabled => !DeleteRequestFileExists;

    public bool DeleteRequestFileExists => !string.IsNullOrEmpty(DeleteRequestFilePath);

    public bool DeleteRequestRemoveButtonEnabled => DeleteRequestFileExists;

    public bool EditRequestAddButtonEnabled => !EditRequestFileExists;

    public bool EditRequestFileExists => !string.IsNullOrEmpty(EditRequestFilePath);

    public bool EditRequestRemoveButtonEnabled => EditRequestFileExists;

    public bool EntityFileExists => !string.IsNullOrEmpty(EntityFilePath);

    public bool GetRequestAddButtonEnabled => !GetRequestFileExists;

    public bool GetRequestFileExists => !string.IsNullOrEmpty(GetRequestFilePath);

    public bool GetRequestRemoveButtonEnabled => GetRequestFileExists;

    public bool RepositoryAddButtonEnabled => !RepositoryFileExists;

    public bool RepositoryFileExists => !string.IsNullOrEmpty(RepositoryFilePath);

    public bool RepositoryRemoveButtonEnabled => RepositoryFileExists;

    public bool ResponseAddButtonEnabled => !ResponseFileExists;

    public bool ResponseFileExists => !string.IsNullOrEmpty(ResponseFilePath);

    public bool ResponseRemoveButtonEnabled => ResponseFileExists;

    public bool SearchRequestAddButtonEnabled => !SearchRequestFileExists;

    public bool SearchRequestFileExists => !string.IsNullOrEmpty(SearchRequestFilePath);

    public bool SearchRequestRemoveButtonEnabled => SearchRequestFileExists;

    public bool ServiceAddButtonEnabled => !ServiceFileExists;

    public bool ServiceFileExists => !string.IsNullOrEmpty(ServiceFilePath);

    public bool ServiceImplAddButtonEnabled => !ServiceImplFileExists;

    public bool ServiceImplFileExists => !string.IsNullOrEmpty(ServiceImplFilePath);

    public bool ServiceImplRemoveButtonEnabled => ServiceImplFileExists;

    public bool ServiceRemoveButtonEnabled => ServiceFileExists;

    public SolidColorBrush AddRequestStatusColor => AddRequestStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush ControllerStatusColor => ControllerStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush DeleteRequestStatusColor => DeleteRequestStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush EditRequestStatusColor => EditRequestStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush GetRequestStatusColor => GetRequestStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush RepositoryStatusColor => RepositoryStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush ResponseStatusColor => ResponseStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush SearchRequestStatusColor => SearchRequestStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush ServiceImplStatusColor => ServiceImplStatus == "OK" ? _colorGreen : _colorRed;

    public SolidColorBrush ServiceStatusColor => ServiceStatus == "OK" ? _colorGreen : _colorRed;

    public string AddRequestStatus => AddRequestFileExists ? "OK" : "FEHLT";

    public string ControllerStatus => ControllerFileExists ? "OK" : "FEHLT";

    public string DeleteRequestStatus => DeleteRequestFileExists ? "OK" : "FEHLT";

    public string EditRequestStatus => EditRequestFileExists ? "OK" : "FEHLT";

    public string GetRequestStatus => GetRequestFileExists ? "OK" : "FEHLT";

    public string PackageName => ProjectPath.Split('\\')[^3] + "." + ProjectPath.Split('\\')[^2] + "." +
                                 ProjectPath.Split('\\')[^1];

    public string ProjectPath { get; set; }

    public string RepositoryStatus => RepositoryFileExists ? "OK" : "FEHLT";

    public string ResponseStatus => ResponseFileExists ? "OK" : "FEHLT";

    public string SearchRequestStatus => SearchRequestFileExists ? "OK" : "FEHLT";

    public string ServiceImplStatus => ServiceImplFileExists ? "OK" : "FEHLT";

    public string ServiceStatus => ServiceFileExists ? "OK" : "FEHLT";

    public string? AddRequestFileName => AddRequestFilePath?.Split('\\')[^1].Split('.')[0];

    public string? AddRequestFilePath { get; set; }

    public string? ControllerFileName => ControllerFilePath?.Split('\\')[^1].Split('.')[0];

    public string? ControllerFilePath { get; set; }

    public string? DeleteRequestFileName => DeleteRequestFilePath?.Split('\\')[^1].Split('.')[0];

    public string? DeleteRequestFilePath { get; set; }

    public string? EditRequestFileName => EditRequestFilePath?.Split('\\')[^1].Split('.')[0];

    public string? EditRequestFilePath { get; set; }

    public string? EntityFileName => EntityFilePath?.Split('\\')[^1].Split('.')[0];

    public string? EntityFileNameLowerCase => char.ToLower(EntityFileName[0]) + EntityFileName.Substring(1);

    public string? EntityFilePath { get; set; }

    public string? GetRequestFileName => GetRequestFilePath?.Split('\\')[^1].Split('.')[0];

    public string? GetRequestFilePath { get; set; }

    public string? RepositoryFileName => RepositoryFilePath?.Split('\\')[^1].Split('.')[0];

    public string? RepositoryFilePath { get; set; }

    public string? ResponseFileName => ResponseFilePath?.Split('\\')[^1].Split('.')[0];

    public string? ResponseFilePath { get; set; }

    public string? SearchRequestFileName => SearchRequestFilePath?.Split('\\')[^1].Split('.')[0];

    public string? SearchRequestFilePath { get; set; }

    public string? ServiceFileName => ServiceFilePath?.Split('\\')[^1].Split('.')[0];

    public string? ServiceFilePath { get; set; }

    public string? ServiceImplFileName => ServiceImplFilePath?.Split('\\')[^1].Split('.')[0];

    public string? ServiceImplFilePath { get; set; }
}