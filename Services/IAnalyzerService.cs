using System.Collections.ObjectModel;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services;

public interface IAnalyzerService
{
    ObservableCollection<Endpoint> GetEndpoints(string projectPath);
}