namespace DamagoApiHelper.Models;

public class Endpoint
{
    public string AddRequestFilePath { get; set; }

    public string AddRequestFileName => AddRequestFilePath.Split('\\')[^1].Split('.')[0];
    
    public string ControllerFilePath { get; set; }
    
    public string ControllerFileName => ControllerFilePath.Split('\\')[^1].Split('.')[0];

    public string DeleteRequestFilePath { get; set; }
    
    public string DeleteRequestFileName => DeleteRequestFilePath.Split('\\')[^1].Split('.')[0];
    
    public string EditRequestFilePath { get; set; }
    
    public string EditRequestFileName => EditRequestFilePath.Split('\\')[^1].Split('.')[0];
    
    public string EntityFilePath { get; set; }
    
    public string EntityFileName => EntityFilePath.Split('\\')[^1].Split('.')[0];
    
    public string GetRequestFilePath { get; set; }
    
    public string GetRequestFileName => GetRequestFilePath.Split('\\')[^1].Split('.')[0];
    
    public string RepositoryFilePath { get; set; }
    
    public string RepositoryFileName => RepositoryFilePath.Split('\\')[^1].Split('.')[0];
    
    public string ResponseFilePath { get; set; }
    
    public string ResponseFileName => ResponseFilePath.Split('\\')[^1].Split('.')[0];
    
    public string SearchRequestFilePath { get; set; }
    
    public string SearchRequestFileName => SearchRequestFilePath.Split('\\')[^1].Split('.')[0];
    
    public string ServiceFilePath { get; set; }
    
    public string ServiceFileName => ServiceFilePath.Split('\\')[^1].Split('.')[0];
    
    public string ServiceImplFilePath { get; set; }
    
    public string ServiceImplFileName => ServiceImplFilePath.Split('\\')[^1].Split('.')[0];
}