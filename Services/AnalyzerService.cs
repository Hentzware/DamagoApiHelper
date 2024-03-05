using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using DamagoApiHelper.Models;

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

        return endpoints;
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
            if (MessageBox.Show($"Das Verzeichnis {path} existiert nicht. Soll das Verzeichnis erstellt werden?",
                    "Achtung!", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }

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