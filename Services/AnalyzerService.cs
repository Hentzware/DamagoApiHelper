using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using DamagoApiHelper.Models;
using Microsoft.WindowsAPICodePack.Shell.Interop;

namespace DamagoApiHelper.Services;

public class AnalyzerService : IAnalyzerService
{
    private string _controllersPath = string.Empty;
    private string _entitiesPath = string.Empty;
    private string _repositoriesPath = string.Empty;
    private string _requestsPath = string.Empty;
    private string _responsesPath = string.Empty;
    private string _servicesPath = string.Empty;

    public ObservableCollection<Endpoint> GetEndpoints(string projectPath)
    {
        CreatePaths(projectPath);
        CreateDirectories();

        var endpoints = new ObservableCollection<Endpoint>();
        var entities = new List<string>();

        if (Directory.Exists(_entitiesPath))
        {
            entities = Directory.EnumerateFiles(_entitiesPath).ToList();
        }

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
            if (string.IsNullOrEmpty(endpoint.EntityFileName)) continue;

            endpoint.ControllerFilePath = GetControllerFilePath(endpoint.EntityFileName + "Controller.java");
            endpoint.ResponseFilePath = GetResponseFilePath(endpoint.EntityFileName + "Response.java");
            endpoint.ServiceFilePath = GetServiceFilePath(endpoint.EntityFileName + "Service.java");
            endpoint.ServiceImplFilePath = GetServiceFilePath(endpoint.EntityFileName + "ServiceImpl.java");
            endpoint.RepositoryFilePath = GetRepositoryFilePath(endpoint.EntityFileName + "Repository.java");

            var requestFolderPath =
                GetRequestFolderPath(endpoint.EntityFileName);

            if (string.IsNullOrEmpty(requestFolderPath)) continue;

            var requestFilePaths = Directory.EnumerateFiles(requestFolderPath).ToList();

            if (!requestFilePaths.Any()) continue;

            endpoint.AddRequestFilePath =
                GetRequestFilePath(requestFilePaths, "Add" + endpoint.EntityFileName + "Request.java");
            endpoint.GetRequestFilePath =
                GetRequestFilePath(requestFilePaths, "Get" + endpoint.EntityFileName + "Request.java");
            endpoint.EditRequestFilePath =
                GetRequestFilePath(requestFilePaths, "Edit" + endpoint.EntityFileName + "Request.java");
            endpoint.DeleteRequestFilePath =
                GetRequestFilePath(requestFilePaths, "Delete" + endpoint.EntityFileName + "Request.java");
            endpoint.SearchRequestFilePath =
                GetRequestFilePath(requestFilePaths, "Search" + endpoint.EntityFileName + "Request.java");
        }

        return endpoints;
    }

    private string? GetControllerFilePath(string fileName)
    {
        var controllers = Directory.EnumerateFiles(_controllersPath);
        return controllers.FirstOrDefault(x => x.Split('\\')[^1].Equals(fileName, StringComparison.OrdinalIgnoreCase));
    }

    private string? GetEntityFilePath(string fileName)
    {
        var entities = Directory.EnumerateFiles(_entitiesPath);
        return entities.FirstOrDefault(x => x.Split('\\')[^1].Equals(fileName, StringComparison.OrdinalIgnoreCase));
    }

    private string? GetRepositoryFilePath(string fileName)
    {
        var repositories = Directory.EnumerateFiles(_repositoriesPath);
        return repositories.FirstOrDefault(x => x.Split('\\')[^1].Equals(fileName, StringComparison.OrdinalIgnoreCase));
    }

    private string? GetRequestFilePath(List<string> requestFilePaths, string fileName)
    {
        return requestFilePaths.FirstOrDefault(x => x.Split('\\')[^1].Equals(fileName, StringComparison.OrdinalIgnoreCase));
    }

    private string? GetRequestFolderPath(string folderName)
    {
        var requestFolders = Directory.EnumerateDirectories(_requestsPath);
        return requestFolders.FirstOrDefault(x => x.Split('\\')[^1].Equals(folderName, StringComparison.OrdinalIgnoreCase));
    }

    private string? GetResponseFilePath(string fileName)
    {
        var responses = Directory.EnumerateFiles(_responsesPath);
        return responses.FirstOrDefault(x => x.Split('\\')[^1].Equals(fileName, StringComparison.OrdinalIgnoreCase));
    }

    private string? GetServiceFilePath(string fileName)
    {
        var services = Directory.EnumerateFiles(_servicesPath);
        return services.FirstOrDefault(x => x.Split('\\')[^1].Equals(fileName, StringComparison.OrdinalIgnoreCase));
    }

    private void CreateDirectories()
    {
        CreateDirectory(_controllersPath);
        CreateDirectory(_entitiesPath);
        CreateDirectory(_repositoriesPath);
        CreateDirectory(_requestsPath);
        CreateDirectory(_responsesPath);
        CreateDirectory(_servicesPath);
    }

    private void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            if (MessageBox.Show($"Das Verzeichnis {path} existiert nicht. Soll das Verzeichnis erstellt werden?", "Achtung!", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            
            Directory.CreateDirectory(path);
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