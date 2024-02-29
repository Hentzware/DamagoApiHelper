using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services
{
    public interface IAnalyzerService
    {
        ObservableCollection<Endpoint> GetEndpoints(string projectPath);
    }
}
