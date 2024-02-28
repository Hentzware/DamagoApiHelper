using System;
using System.Collections.Generic;
using System.IO;
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

    public void AddAddRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadAddRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Add{endpoint.EntityFileName}Request.java");
    }

    public void AddController(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadControllerTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\controllers\\{endpoint.EntityFileName}Controller.java");
    }

    public void AddDeleteRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadDeleteRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Delete{endpoint.EntityFileName}Request.java");
    }

    public void AddEditRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadEditRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Edit{endpoint.EntityFileName}Request.java");
    }

    public void AddEntity(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadEntityTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\entities\\{endpoint.EntityFileName}.java");
    }

    public void AddGetRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadGetRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Get{endpoint.EntityFileName}Request.java");
    }

    public void AddRepository(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadRepositoryTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\repositories\\{endpoint.EntityFileName}Repository.java");
    }

    public void AddResponse(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadResponseTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\responses\\{endpoint.EntityFileName}Response.java");
    }

    public void AddSearchRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadSearchRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template,
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Search{endpoint.EntityFileName}Request.java");
    }

    public void AddService(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadServiceTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\services\\{endpoint.EntityFileName}Service.java");
    }

    public void AddServiceImpl(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadServiceImplTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
        WriteTemplateFile(template, $"{endpoint.ProjectPath}\\services\\{endpoint.EntityFileName}ServiceImpl.java");
    }

    public void RemoveAddRequest(Endpoint endpoint)
    {
        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Add{endpoint.EntityFileName}Request.java");
    }

    public void RemoveController(Endpoint endpoint)
    {
        RemoveTemplateFile($"{endpoint.ProjectPath}\\controllers\\{endpoint.EntityFileName}Controller.java");
    }

    public void RemoveDeleteRequest(Endpoint endpoint)
    {
        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Delete{endpoint.EntityFileName}Request.java");
    }

    public void RemoveEditRequest(Endpoint endpoint)
    {
        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Edit{endpoint.EntityFileName}Request.java");
    }

    public void RemoveEntity(Endpoint endpoint)
    {
        
    }

    public void RemoveGetRequest(Endpoint endpoint)
    {
        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Get{endpoint.EntityFileName}Request.java");
    }

    public void RemoveRepository(Endpoint endpoint)
    {
        RemoveTemplateFile($"{endpoint.ProjectPath}\\repositories\\{endpoint.EntityFileName}Repository.java");
    }

    public void RemoveResponse(Endpoint endpoint)
    {
        RemoveTemplateFile($"{endpoint.ProjectPath}\\responses\\{endpoint.EntityFileName}Response.java");
    }

    public void RemoveSearchRequest(Endpoint endpoint)
    {
        RemoveTemplateFile(
            $"{endpoint.ProjectPath}\\requests\\{endpoint.EntityFileName}\\Search{endpoint.EntityFileName}Request.java");
    }

    public void RemoveService(Endpoint endpoint)
    {
        RemoveTemplateFile($"{endpoint.ProjectPath}\\services\\{endpoint.EntityFileName}Service.java");
    }

    public void RemoveServiceImpl(Endpoint endpoint)
    {
        RemoveTemplateFile($"{endpoint.ProjectPath}\\services\\{endpoint.EntityFileName}ServiceImpl.java");
    }

    public void AddEndpoint(Endpoint endpoint)
    {
        
    }

    public void RemoveEndpoint(Endpoint endpoint)
    {
        
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
        File.WriteAllText(filePath, template);
    }
}