using System.IO;
using System.Windows.Media;

namespace DamagoApiHelper.Models;

public class Endpoint
{
    private readonly SolidColorBrush _colorGreen = new(Colors.Green);

    private readonly SolidColorBrush _colorRed = new(Colors.Red);

    public bool AddRequestAddButtonEnabled => !AddRequestFileExists;

    public bool AddRequestFileExists => File.Exists(AddRequestFilePath);

    public bool AddRequestRemoveButtonEnabled => AddRequestFileExists;

    public bool ControllerAddButtonEnabled => !ControllerFileExists;

    public bool ControllerFileExists => File.Exists(ControllerFilePath);

    public bool ControllerRemoveButtonEnabled => ControllerFileExists;

    public bool ControllersFolderExists => Directory.Exists(ControllersFolderPath);

    public bool DeleteRequestAddButtonEnabled => !DeleteRequestFileExists;

    public bool DeleteRequestFileExists => File.Exists(DeleteRequestFilePath);

    public bool DeleteRequestRemoveButtonEnabled => DeleteRequestFileExists;

    public bool EditRequestAddButtonEnabled => !EditRequestFileExists;

    public bool EditRequestFileExists => File.Exists(EditRequestFilePath);

    public bool EditRequestRemoveButtonEnabled => EditRequestFileExists;

    public bool EntitiesFolderExists => Directory.Exists(EntitiesFolderPath);

    public bool EntityFileExists => File.Exists(EntityFilePath);

    public bool GetRequestAddButtonEnabled => !GetRequestFileExists;

    public bool GetRequestFileExists => File.Exists(GetRequestFilePath);

    public bool GetRequestRemoveButtonEnabled => GetRequestFileExists;

    public bool RepositoriesFolderExists => Directory.Exists(RepositoriesFolderPath);

    public bool RepositoryAddButtonEnabled => !RepositoryFileExists;

    public bool RepositoryFileExists => File.Exists(RepositoryFilePath);

    public bool RepositoryRemoveButtonEnabled => RepositoryFileExists;

    public bool RequestsFolderExists => Directory.Exists(RequestsFolderPath);

    public bool ResponseAddButtonEnabled => !ResponseFileExists;

    public bool ResponseFileExists => File.Exists(ResponseFilePath);

    public bool ResponseRemoveButtonEnabled => ResponseFileExists;

    public bool ResponsesFolderExists => Directory.Exists(ResponsesFolderPath);

    public bool SearchRequestAddButtonEnabled => !SearchRequestFileExists;

    public bool SearchRequestFileExists => File.Exists(SearchRequestFilePath);

    public bool SearchRequestRemoveButtonEnabled => SearchRequestFileExists;

    public bool ServiceAddButtonEnabled => !ServiceFileExists;

    public bool ServiceFileExists => File.Exists(ServiceFilePath);

    public bool ServiceImplAddButtonEnabled => !ServiceImplFileExists;

    public bool ServiceImplFileExists => File.Exists(ServiceImplFilePath);

    public bool ServiceImplRemoveButtonEnabled => ServiceImplFileExists;

    public bool ServiceRemoveButtonEnabled => ServiceFileExists;

    public bool ServicesFolderExists => Directory.Exists(ServicesFolderPath);

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

    public string AddRequestFileName => $"Add{EntityFileName}Request.java";

    public string AddRequestFilePath =>
        Path.Combine(ProjectPath, "requests", EntityFileNameLowerCase, AddRequestFileName);

    public string AddRequestStatus => AddRequestFileExists ? "OK" : "FEHLT";

    public string ControllerFileName => $"{EntityFileName}Controller.java";

    public string ControllerFilePath => Path.Combine(ProjectPath, "controllers", ControllerFileName);

    public string ControllersFolderPath => Path.Combine(ProjectPath, "controllers");

    public string ControllerStatus => ControllerFileExists ? "OK" : "FEHLT";

    public string DeleteRequestFileName => $"Delete{EntityFileName}Request.java";

    public string DeleteRequestFilePath =>
        Path.Combine(ProjectPath, "requests", EntityFileNameLowerCase, DeleteRequestFileName);

    public string DeleteRequestStatus => DeleteRequestFileExists ? "OK" : "FEHLT";

    public string EditRequestFileName => $"Edit{EntityFileName}Request.java";

    public string EditRequestFilePath =>
        Path.Combine(ProjectPath, "requests", EntityFileNameLowerCase, EditRequestFileName);

    public string EditRequestStatus => EditRequestFileExists ? "OK" : "FEHLT";

    public string EntitiesFolderPath => Path.Combine(ProjectPath, "entities");

    public string EntityFileName => EntityFilePath.Split('\\')[^1].Split('.')[0];

    public string EntityFileNameLowerCase => char.ToLower(EntityFileName[0]) + EntityFileName.Substring(1);

    public string EntityFilePath { get; set; }

    public string GetRequestFileName => $"Get{EntityFileName}Request.java";

    public string GetRequestFilePath =>
        Path.Combine(ProjectPath, "requests", EntityFileNameLowerCase, GetRequestFileName);

    public string GetRequestStatus => GetRequestFileExists ? "OK" : "FEHLT";

    public string PackageName => ProjectPath.Split('\\')[^3] + "." + ProjectPath.Split('\\')[^2] + "." +
                                 ProjectPath.Split('\\')[^1];

    public string ProjectPath { get; set; }

    public string RepositoriesFolderPath => Path.Combine(ProjectPath, "repositories");

    public string RepositoryFileName => $"{EntityFileName}Repository.java";

    public string RepositoryFilePath => Path.Combine(ProjectPath, "repositories", RepositoryFileName);

    public string RepositoryStatus => RepositoryFileExists ? "OK" : "FEHLT";

    public string RequestsFolderPath => Path.Combine(ProjectPath, "requests");

    public string ResponseFileName => $"{EntityFileName}Response.java";

    public string ResponseFilePath => Path.Combine(ProjectPath, "responses", ResponseFileName);

    public string ResponsesFolderPath => Path.Combine(ProjectPath, "responses");

    public string ResponseStatus => ResponseFileExists ? "OK" : "FEHLT";

    public string SearchRequestFileName => $"Search{EntityFileName}Request.java";

    public string SearchRequestFilePath =>
        Path.Combine(ProjectPath, "requests", EntityFileNameLowerCase, SearchRequestFileName);

    public string SearchRequestStatus => SearchRequestFileExists ? "OK" : "FEHLT";

    public string ServiceFileName => $"{EntityFileName}Service.java";

    public string ServiceFilePath => Path.Combine(ProjectPath, "services", ServiceFileName);

    public string ServiceImplFileName => $"{EntityFileName}ServiceImpl.java";

    public string ServiceImplFilePath => Path.Combine(ProjectPath, "services", ServiceImplFileName);

    public string ServiceImplStatus => ServiceImplFileExists ? "OK" : "FEHLT";

    public string ServicesFolderPath => Path.Combine(ProjectPath, "services");

    public string ServiceStatus => ServiceFileExists ? "OK" : "FEHLT";

    public string SpAddFilePath { get; set; }

    public string SpDeleteFilePath { get; set; }

    public string SpDeletePermanentFilePath { get; set; }

    public string SpGetByIdFilePath { get; set; }

    public string SpGetDeletedFilePath { get; set; }

    public string SpGetFilePath { get; set; }

    public string SpSearchFilePath { get; set; }
}