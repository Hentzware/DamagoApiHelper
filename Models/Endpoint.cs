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

    public bool SpAddFileExists => File.Exists(SpAddFilePath);

    public bool SpDeleteFileExists => File.Exists(SpDeleteFilePath);

    public bool SpDeletePermanentFileExists => File.Exists(SpDeletePermanentFilePath);

    public bool SpGetByIdFileExists => File.Exists(SpGetByIdFilePath);

    public bool SpGetDeletedFileExists => File.Exists(SpGetDeletedFilePath);

    public bool SpGetFileExists => File.Exists(SpGetFilePath);

    public bool SpSearchFileExists => File.Exists(SpSearchFilePath);

    public bool SpUndeleteFileExists => File.Exists(SpUndeleteFilePath);

    public bool SpUpdateFileExists => File.Exists(SpUpdateFilePath);

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

    public string AddRequestFileName => $"Add{EntityName}Request.java";

    public string AddRequestFilePath => Path.Combine(ProjectPath, "requests", EntityNameLowerCase, AddRequestFileName);

    public string AddRequestStatus => AddRequestFileExists ? "OK" : "FEHLT";

    public string ControllerFileName => $"{EntityName}Controller.java";

    public string ControllerFilePath => Path.Combine(ProjectPath, "controllers", ControllerFileName);

    public string ControllersFolderPath => Path.Combine(ProjectPath, "controllers");

    public string ControllerStatus => ControllerFileExists ? "OK" : "FEHLT";

    public string DeleteRequestFileName => $"Delete{EntityName}Request.java";

    public string DeleteRequestFilePath => Path.Combine(ProjectPath, "requests", EntityNameLowerCase, DeleteRequestFileName);

    public string DeleteRequestStatus => DeleteRequestFileExists ? "OK" : "FEHLT";

    public string EditRequestFileName => $"Edit{EntityName}Request.java";

    public string EditRequestFilePath => Path.Combine(ProjectPath, "requests", EntityNameLowerCase, EditRequestFileName);

    public string EditRequestStatus => EditRequestFileExists ? "OK" : "FEHLT";

    public string EntitiesFolderPath => Path.Combine(ProjectPath, "entities");

    public string EntityFileName => $"{EntityName}.java";

    public string EntityFilePath => Path.Combine(ProjectPath, "entities", EntityFileName);

    public string EntityName { get; set; }

    public string EntityNameLowerCase => char.ToLower(EntityName[0]) + EntityName.Substring(1);

    public string GetRequestFileName => $"Get{EntityName}Request.java";

    public string GetRequestFilePath => Path.Combine(ProjectPath, "requests", EntityNameLowerCase, GetRequestFileName);

    public string GetRequestStatus => GetRequestFileExists ? "OK" : "FEHLT";

    public string PackageName => ProjectPath.Split('\\')[^3] + "." + ProjectPath.Split('\\')[^2] + "." + ProjectPath.Split('\\')[^1];

    public string ProjectPath { get; set; }

    public string RepositoriesFolderPath => Path.Combine(ProjectPath, "repositories");

    public string RepositoryFileName => $"{EntityName}Repository.java";

    public string RepositoryFilePath => Path.Combine(ProjectPath, "repositories", RepositoryFileName);

    public string RepositoryStatus => RepositoryFileExists ? "OK" : "FEHLT";

    public string RequestsFolderPath => Path.Combine(ProjectPath, "requests");

    public string ResponseFileName => $"{EntityName}Response.java";

    public string ResponseFilePath => Path.Combine(ProjectPath, "responses", ResponseFileName);

    public string ResponsesFolderPath => Path.Combine(ProjectPath, "responses");

    public string ResponseStatus => ResponseFileExists ? "OK" : "FEHLT";

    public string SearchRequestFileName => $"Search{EntityName}Request.java";

    public string SearchRequestFilePath => Path.Combine(ProjectPath, "requests", EntityNameLowerCase, SearchRequestFileName);

    public string SearchRequestStatus => SearchRequestFileExists ? "OK" : "FEHLT";

    public string ServiceFileName => $"{EntityName}Service.java";

    public string ServiceFilePath => Path.Combine(ProjectPath, "services", ServiceFileName);

    public string ServiceImplFileName => $"{EntityName}ServiceImpl.java";

    public string ServiceImplFilePath => Path.Combine(ProjectPath, "services", ServiceImplFileName);

    public string ServiceImplStatus => ServiceImplFileExists ? "OK" : "FEHLT";

    public string ServicesFolderPath => Path.Combine(ProjectPath, "services");

    public string ServiceStatus => ServiceFileExists ? "OK" : "FEHLT";

    public string SpAddFileName => $"sp_{EntityName}_Add.sql";

    public string SpAddFilePath { get; set; }

    public string SpDeleteFileName => $"sp_{EntityName}_Delete.sql";

    public string SpDeleteFilePath { get; set; }

    public string SpDeletePermanentFileName => $"sp_{EntityName}_DeletePermanent.sql";

    public string SpDeletePermanentFilePath { get; set; }

    public string SpGetByIdFileName => $"sp_{EntityName}_GetById.sql";

    public string SpGetByIdFilePath { get; set; }

    public string SpGetDeletedFileName => $"sp_{EntityName}_GetDeleted.sql";

    public string SpGetDeletedFilePath { get; set; }

    public string SpGetFileName => $"sp_{EntityName}_Get.sql";

    public string SpGetFilePath { get; set; }

    public string SpSearchFileName => $"sp_{EntityName}_Search.sql";

    public string SpSearchFilePath { get; set; }

    public string SpUndeleteFileName => $"sp_{EntityName}_Undelete.sql";

    public string SpUndeleteFilePath { get; set; }

    public string SpUpdateFileName => $"sp_{EntityName}_Update.sql";

    public string SpUpdateFilePath { get; set; }
}