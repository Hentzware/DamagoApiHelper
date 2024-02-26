using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services
{
    public interface IProjectAnalyzerService
    {
        List<Endpoint> GetEndpoints(string projectPath);
    }
}
