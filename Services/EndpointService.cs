using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services;

public class EndpointService : IEndpointService
{
    private readonly Assembly assembly = Assembly.GetExecutingAssembly();

    private string _controllersPath = string.Empty;
    private string _entitiesPath = string.Empty;
    private string _repositoriesPath = string.Empty;
    private string _requestsPath = string.Empty;
    private string _responsesPath = string.Empty;
    private string _servicesPath = string.Empty;

    public void Add(string srcFile, string destFile, Dictionary<string, string> replacementDictionary)
    {
        var template = LoadTemplate(srcFile);
        template = ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template, destFile);
    }

    public void Remove(string destFile, bool removeEmptyFolder)
    {
        if (File.Exists(destFile)) File.Delete(destFile);

        if (removeEmptyFolder)
        {
            var folder = Path.GetDirectoryName(destFile);
            var numFiles = Directory.EnumerateFiles(folder).Count();

            if (numFiles == 0) Directory.Delete(folder);
        }
    }

    public ObservableCollection<Endpoint> GetEndpoints(string projectPath)
    {
        CreatePaths(projectPath);
        CreateDirectories();

        var endpoints = new ObservableCollection<Endpoint>();
        var entities = new List<string>();

        if (Directory.Exists(_entitiesPath)) entities = Directory.EnumerateFiles(_entitiesPath).ToList();

        foreach (var entity in entities)
        {
            var endpoint = new Endpoint
            {
                ProjectPath = projectPath,
                EntityName = entity.Split('\\')[^1].Split('.')[^2]
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
                return;

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

    private string LoadTemplate(string templateName)
    {
        var templateFile = $"DamagoApiHelper.Templates.{templateName}.txt";
        return ReadTemplateFile(templateFile);
    }

    private string ReadTemplateFile(string templateFile)
    {
        using (var stream = assembly.GetManifestResourceStream(templateFile))
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    private string ReplaceText(string template, Dictionary<string, string> replacementDictionary)
    {
        foreach (var replacementKeyValuePair in replacementDictionary) template = template.Replace(replacementKeyValuePair.Key, replacementKeyValuePair.Value);

        return template;
    }

    private void WriteTemplateFile(string template, string filePath)
    {
        Remove(filePath, false);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        File.WriteAllText(filePath, template);
    }
}