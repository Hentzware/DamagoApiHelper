using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services;

public class ProjectAnalyzerService : IProjectAnalyzerService
{
    private string _controllersPath = string.Empty;
    private string _entitiesPath = string.Empty;
    private string _repositoriesPath = string.Empty;
    private string _requestsPath = string.Empty;
    private string _responsesPath = string.Empty;
    private string _servicesPath = string.Empty;

    public List<Endpoint> GetEndpoints(string projectPath)
    {
        CreatePaths(projectPath);
        CheckFolders();

        var endpoints = new List<Endpoint>();

        var controllers = Directory.EnumerateFiles(_controllersPath);
        var entities = Directory.EnumerateFiles(_entitiesPath);
        var requests = Directory.EnumerateDirectories(_requestsPath);
        var responses = Directory.EnumerateFiles(_responsesPath);
        var services = Directory.EnumerateFiles(_servicesPath);
        var repositories = Directory.EnumerateFiles(_repositoriesPath);

        foreach (var entity in entities)
        {
            var endpoint = new Endpoint
            {
                ProjectPath = projectPath,
                EntityFilePath = entity
            };

            endpoints.Add(endpoint);
        }

        foreach (var endpoint in endpoints)
        {
            endpoint.ControllerFilePath = controllers.FirstOrDefault(x => x.Contains(endpoint.EntityFileName + "Controller.java"));
            endpoint.ResponseFilePath = responses.FirstOrDefault(x => x.Contains(endpoint.EntityFileName + "Response.java"));
            endpoint.ServiceFilePath = services.FirstOrDefault(x => x.Contains(endpoint.EntityFileName + "Service.java"));
            endpoint.ServiceImplFilePath = services.FirstOrDefault(x => x.Contains(endpoint.EntityFileName + "ServiceImpl.java"));
            endpoint.RepositoryFilePath = repositories.FirstOrDefault(x => x.Contains(endpoint.EntityFileName + "Repository.java"));

            var requestFolderPath = requests.FirstOrDefault(x => x.Contains(char.ToLower(endpoint.EntityFileName[0]) + endpoint.EntityFileName.Substring(1)));

            if (requestFolderPath != null)
            {
                var requestFiles = Directory.EnumerateFiles(requestFolderPath);
                endpoint.AddRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Add" + endpoint.EntityFileName + "Request.java"));
                endpoint.GetRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Get" + endpoint.EntityFileName + "Request.java"));
                endpoint.EditRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Edit" + endpoint.EntityFileName + "Request.java"));
                endpoint.DeleteRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Delete" + endpoint.EntityFileName + "Request.java"));
                endpoint.SearchRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Search" + endpoint.EntityFileName + "Request.java"));
            }
        }

        return endpoints;
    }

    private void CheckFolders()
    {
        if (!Directory.Exists(_controllersPath))
        {
            Directory.CreateDirectory(_controllersPath);
        }

        if (!Directory.Exists(_entitiesPath))
        {
            Directory.CreateDirectory(_entitiesPath);
        }

        if (!Directory.Exists(_repositoriesPath))
        {
            Directory.CreateDirectory(_repositoriesPath);
        }

        if (!Directory.Exists(_requestsPath))
        {
            Directory.CreateDirectory(_requestsPath);
        }

        if (!Directory.Exists(_responsesPath))
        {
            Directory.CreateDirectory(_responsesPath);
        }

        if (!Directory.Exists(_servicesPath))
        {
            Directory.CreateDirectory(_servicesPath);
        }
    }

    private void CreatePaths(string projectPath)
    {
        _entitiesPath = projectPath + "\\entities";
        _controllersPath = projectPath + "\\controllers";
        _requestsPath = projectPath + "\\requests";
        _responsesPath = projectPath + "\\responses";
        _servicesPath = projectPath + "\\services";
        _repositoriesPath = projectPath + "\\repositories";
    }
}