using System.Collections.Generic;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services;

public interface IEndpointService
{
    void AddAddRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddController(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddDeleteRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddEditRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddEndpoint(Endpoint? endpoint);

    void AddEntity(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddGetRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddRepository(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddResponse(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddSearchRequest(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddService(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void AddServiceImpl(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpAdd(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpDelete(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpDeletePermanent(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpGet(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpGetById(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpGetDeleted(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpSearch(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpUndelete(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);
    
    void AddSpUpdate(Endpoint? endpoint, Dictionary<string, string> replacementDictionary);

    void RemoveAddRequest(Endpoint? endpoint);

    void RemoveController(Endpoint? endpoint);

    void RemoveDeleteRequest(Endpoint? endpoint);

    void RemoveEditRequest(Endpoint? endpoint);

    void RemoveEndpoint(Endpoint? endpoint);

    void RemoveEntity(Endpoint? endpoint);

    void RemoveGetRequest(Endpoint? endpoint);

    void RemoveRepository(Endpoint? endpoint);

    void RemoveResponse(Endpoint? endpoint);

    void RemoveSearchRequest(Endpoint? endpoint);

    void RemoveService(Endpoint? endpoint);

    void RemoveServiceImpl(Endpoint? endpoint);
    
    void RemoveSpAdd(Endpoint? endpoint);
    
    void RemoveSpDelete(Endpoint? endpoint);
    
    void RemoveSpDeletePermanent(Endpoint? endpoint);
    
    void RemoveSpGet(Endpoint? endpoint);
    
    void RemoveSpGetById(Endpoint? endpoint);
    
    void RemoveSpGetDeleted(Endpoint? endpoint);
    
    void RemoveSpSearch(Endpoint? endpoint);
    
    void RemoveSpUndelete(Endpoint? endpoint);
    
    void RemoveSpUpdate(Endpoint? endpoint);
}