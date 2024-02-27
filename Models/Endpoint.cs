namespace DamagoApiHelper.Models;

public class Endpoint
{
    public bool AddRequestFileExists => !string.IsNullOrEmpty(AddRequestFilePath);

    public bool ControllerFileExists => !string.IsNullOrEmpty(ControllerFilePath);

    public bool DeleteRequestFileExists => !string.IsNullOrEmpty(DeleteRequestFilePath);

    public bool EditRequestFileExists => !string.IsNullOrEmpty(EditRequestFilePath);

    public bool EntityFileExists => !string.IsNullOrEmpty(EntityFilePath);

    public bool GetRequestFileExists => !string.IsNullOrEmpty(GetRequestFilePath);

    public bool RepositoryFileExists => !string.IsNullOrEmpty(RepositoryFilePath);

    public bool ResponseFileExists => !string.IsNullOrEmpty(ResponseFilePath);

    public bool SearchRequestFileExists => !string.IsNullOrEmpty(SearchRequestFilePath);

    public bool ServiceFileExists => !string.IsNullOrEmpty(ServiceFilePath);

    public bool ServiceImplFileExists => !string.IsNullOrEmpty(ServiceImplFilePath);

    public string AddRequestFileName => AddRequestFilePath.Split('\\')[^1].Split('.')[0];

    public string AddRequestFilePath { get; set; }

    public string ControllerFileName => ControllerFilePath.Split('\\')[^1].Split('.')[0];

    public string ControllerFilePath { get; set; }

    public string DeleteRequestFileName => DeleteRequestFilePath.Split('\\')[^1].Split('.')[0];

    public string DeleteRequestFilePath { get; set; }

    public string EditRequestFileName => EditRequestFilePath.Split('\\')[^1].Split('.')[0];

    public string EditRequestFilePath { get; set; }

    public string EntityFileName => EntityFilePath.Split('\\')[^1].Split('.')[0];

    public string EntityFilePath { get; set; }

    public string GetRequestFileName => GetRequestFilePath.Split('\\')[^1].Split('.')[0];

    public string GetRequestFilePath { get; set; }
    
    public string ProjectPath { get; set; }

    public string RepositoryFileName => RepositoryFilePath.Split('\\')[^1].Split('.')[0];

    public string RepositoryFilePath { get; set; }

    public string ResponseFileName => ResponseFilePath.Split('\\')[^1].Split('.')[0];

    public string ResponseFilePath { get; set; }

    public string SearchRequestFileName => SearchRequestFilePath.Split('\\')[^1].Split('.')[0];

    public string SearchRequestFilePath { get; set; }

    public string ServiceFileName => ServiceFilePath.Split('\\')[^1].Split('.')[0];

    public string ServiceFilePath { get; set; }

    public string ServiceImplFileName => ServiceImplFilePath.Split('\\')[^1].Split('.')[0];

    public string ServiceImplFilePath { get; set; }
}