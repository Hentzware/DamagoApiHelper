using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services;

public class EndpointService : IEndpointService
{
    private readonly ITemplateService _templateService;
    private readonly ITextService _textService;

    public EndpointService(ITemplateService templateService, ITextService textService)
    {
        _templateService = templateService;
        _textService = textService;
    }

    public void AddAddRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("AddRequest");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Add{endpoint.EntityFileName}Request.java");
    }

    public void AddController(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("Controller");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\controllers\\{endpoint.EntityFileName}Controller.java");
    }

    public void AddDeleteRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("DeleteRequest");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Delete{endpoint.EntityFileName}Request.java");
    }

    public void AddEditRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("EditRequest");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Edit{endpoint.EntityFileName}Request.java");
    }

    public void AddEntity(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("Entity");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\entities\\{endpoint.EntityFileName}.java");
    }

    public void AddGetRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("GetRequest");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Get{endpoint.EntityFileName}Request.java");
    }

    public void AddRepository(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("Repository");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\repositories\\{endpoint.EntityFileName}Repository.java");
    }

    public void AddResponse(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("Response");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\responses\\{endpoint.EntityFileName}Response.java");
    }

    public void AddSearchRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("SearchRequest");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Search{endpoint.EntityFileName}Request.java");
    }

    public void AddService(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("Service");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\services\\{endpoint.EntityFileName}Service.java");
    }

    public void AddServiceImpl(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("ServiceImpl");

        template = _textService.ReplaceText(template, replacementDictionary);

        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\services\\{endpoint.EntityFileName}ServiceImpl.java");
    }

    public void AddSpAdd(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        if (endpoint == null)
        {
            return;
        }

        var template = _templateService.LoadTemplate("SpAdd");
        MessageBox.Show(Path.GetFullPath(endpoint.ProjectPath));
        MessageBox.Show(Path.GetFullPath(
            $"..\\..\\..\\..\\..\\{endpoint.ProjectPath}\\SqlScripts\\StoredProcedures\\{endpoint.EntityFileName}\\Sp{endpoint.EntityFileName}Add.sql"));
        return;
        WriteTemplateFile(template, $"..\\..\\..\\..\\..\\{endpoint.ProjectPath}\\SqlScripts\\StoredProcedures\\{endpoint.EntityFileName}\\Sp{endpoint.EntityFileName}Add.sql");
    }

    public void AddSpDelete(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        throw new NotImplementedException();
    }

    public void AddSpDeletePermanent(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        throw new NotImplementedException();
    }

    public void AddSpGet(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        throw new NotImplementedException();
    }

    public void AddSpGetById(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        throw new NotImplementedException();
    }

    public void AddSpGetDeleted(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        throw new NotImplementedException();
    }

    public void AddSpSearch(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        throw new NotImplementedException();
    }

    public void AddSpUndelete(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        throw new NotImplementedException();
    }

    public void AddSpUpdate(Endpoint? endpoint, Dictionary<string, string> replacementDictionary)
    {
        throw new NotImplementedException();
    }

    public void RemoveAddRequest(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Add{endpoint.EntityFileName}Request.java");
        RemoveRequestDirectory(endpoint);
    }

    public void RemoveController(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile($"{endpoint.ProjectPath}\\controllers\\{endpoint.EntityFileName}Controller.java");
    }

    public void RemoveDeleteRequest(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Delete{endpoint.EntityFileName}Request.java");
        RemoveRequestDirectory(endpoint);
    }

    public void RemoveEditRequest(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Edit{endpoint.EntityFileName}Request.java");
        RemoveRequestDirectory(endpoint);
    }

    public void RemoveEntity(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveAddRequest(endpoint);
        RemoveController(endpoint);
        RemoveDeleteRequest(endpoint);
        RemoveEditRequest(endpoint);
        RemoveGetRequest(endpoint);
        RemoveRepository(endpoint);
        RemoveResponse(endpoint);
        RemoveSearchRequest(endpoint);
        RemoveService(endpoint);
        RemoveServiceImpl(endpoint);

        RemoveTemplateFile(endpoint.EntityFilePath);
    }

    public void RemoveGetRequest(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Get{endpoint.EntityFileName}Request.java");
        RemoveRequestDirectory(endpoint);
    }

    public void RemoveRepository(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile($"{endpoint.ProjectPath}\\repositories\\{endpoint.EntityFileName}Repository.java");
    }

    public void RemoveResponse(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile($"{endpoint.ProjectPath}\\responses\\{endpoint.EntityFileName}Response.java");
    }

    public void RemoveSearchRequest(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}\\Search{endpoint.EntityFileName}Request.java");
        RemoveRequestDirectory(endpoint);
    }

    public void RemoveService(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile($"{endpoint.ProjectPath}\\services\\{endpoint.EntityFileName}Service.java");
    }

    public void RemoveServiceImpl(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
            return;
        }

        RemoveTemplateFile($"{endpoint.ProjectPath}\\services\\{endpoint.EntityFileName}ServiceImpl.java");
    }

    public void RemoveSpAdd(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSpDelete(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSpDeletePermanent(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSpGet(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSpGetById(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSpGetDeleted(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSpSearch(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSpUndelete(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSpUpdate(Endpoint? endpoint)
    {
        throw new NotImplementedException();
    }

    public void AddEndpoint(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
        }
    }

    public void RemoveEndpoint(Endpoint? endpoint)
    {
        if (endpoint == null)
        {
        }
    }

    private void RemoveRequestDirectory(Endpoint? endpoint)
    {
        var folderPath = $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileNameLowerCase}";

        if (Directory.Exists(folderPath))
        {
            if (!Directory.EnumerateFiles(folderPath).Any())
            {
                Directory.Delete(folderPath);
            }
        }
    }

    private void RemoveTemplateFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    private void WriteTemplateFile(string template, string filePath)
    {
        RemoveTemplateFile(filePath);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        File.WriteAllText(filePath, template);
    }
}