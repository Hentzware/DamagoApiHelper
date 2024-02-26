using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamagoApiHelper.Services
{
    public class ProjectAnalyzerService : IProjectAnalyzerService
    {
        public List<string> GetEndpoints(string projectPath)
        {
            List<string> _endpoints = new List<string>();
            
            var temp = Directory.EnumerateFiles(projectPath + "\\entities");

            foreach (var s in temp)
            {
                _endpoints.Add(s.Split('\\')[^1].Split('.')[0]);
            }
            
            return _endpoints;
        }
    }
}
