using System;
using System.Collections.Generic;
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
    }

    public void AddController(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadControllerTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void AddDeleteRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadDeleteRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void AddEditRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadEditRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void AddGetRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadGetRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void AddRepository(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadRepositoryTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void AddResponse(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadResponseTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void AddSearchRequest(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadSearchRequestTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void AddService(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadServiceTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void AddServiceImpl(Endpoint endpoint, Dictionary<string, string> replacementDictionary)
    {
        var template = _templateService.LoadServiceImplTemplate();
        template = _textService.ReplaceText(template, replacementDictionary);
    }

    public void RemoveAddRequest(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveController(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveDeleteRequest(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveEditRequest(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveGetRequest(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveRepository(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveResponse(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveSearchRequest(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveService(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }

    public void RemoveServiceImpl(Endpoint endpoint)
    {
        throw new NotImplementedException();
    }
}