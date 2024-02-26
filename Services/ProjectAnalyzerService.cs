using System.Collections.Generic;
using System.IO;
using System.Linq;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services;

public class ProjectAnalyzerService : IProjectAnalyzerService
{
    private string _controllersPath;
    private string _entitiesPath;
    private string _repositoriesPath;
    private string _requestsPath;
    private string _responsesPath;
    private string _servicesPath;

    public List<Endpoint> GetEndpoints(string projectPath)
    {
        CreatePaths(projectPath);
        CheckFolders();

        var _endpoints = new List<Endpoint>();

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
                EntityFilePath = entity
            };

            _endpoints.Add(endpoint);
        }

        foreach (var endpoint in _endpoints)
        {
            endpoint.ControllerFilePath = controllers.FirstOrDefault(x => x.Contains(endpoint.EntityFileName));
            endpoint.ResponseFilePath = responses.FirstOrDefault(x => x.Contains(endpoint.EntityFileName));
            endpoint.ServiceFilePath = services.FirstOrDefault(x => x.Contains(endpoint.EntityFileName + "Service"));
            endpoint.ServiceImplFilePath = services.FirstOrDefault(x => x.Contains(endpoint.EntityFileName + "ServiceImpl"));
            endpoint.RepositoryFilePath = repositories.FirstOrDefault(x => x.Contains(endpoint.EntityFileName));

            var requestFolderPath = requests.FirstOrDefault(x => x.Contains(endpoint.EntityFileName.ToLower()));

            if (requestFolderPath != null)
            {
                var requestFiles = Directory.EnumerateFiles(requestFolderPath);
                endpoint.AddRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Add" + endpoint.EntityFileName));
                endpoint.GetRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Get" + endpoint.EntityFileName));
                endpoint.EditRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Edit" + endpoint.EntityFileName));
                endpoint.DeleteRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Delete" + endpoint.EntityFileName));
                endpoint.SearchRequestFilePath = requestFiles.FirstOrDefault(x => x.Contains("Search" + endpoint.EntityFileName));
            }
        }

        return _endpoints;
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