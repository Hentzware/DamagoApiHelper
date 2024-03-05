using System.Collections.Generic;
using System.Collections.ObjectModel;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services;

public interface IEndpointService
{
    ObservableCollection<Endpoint> GetEndpoints(string projectPath);
    
    void Add(string srcFile, string destFile, Dictionary<string, string> replacementDictionary);

    void Remove(string destFile, bool removeEmptyFolder);
}