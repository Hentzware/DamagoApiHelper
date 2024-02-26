using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamagoApiHelper.Services
{
    public interface IProjectAnalyzerService
    {
        List<string> GetEndpoints(string projectPath);
    }
}
