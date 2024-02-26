using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DamagoApiHelper.Services
{
    public class TextReplaceService : ITextReplaceService
    {
        private Dictionary<string, string> _templateFileResources = new Dictionary<string, string>()
        {
            { "AddRequest", "DamagoApiHelper.Templates.AddRequest.txt" },
            { "Controller", "DamagoApiHelper.Templates.Controller.txt" },
            { "DeleteRequest", "DamagoApiHelper.Templates.DeleteRequest.txt" },
            { "EditRequest", "DamagoApiHelper.Templates.EditRequest.txt" },
            { "Entity", "DamagoApiHelper.Templates.Entity.txt" },
            { "GetRequest", "DamagoApiHelper.Templates.GetRequest.txt" },
            { "Repository", "DamagoApiHelper.Templates.Repository.txt" },
            { "Response", "DamagoApiHelper.Templates.Response.txt" },
            { "SearchRequest", "DamagoApiHelper.Templates.SearchRequest.txt" },
            { "Service", "DamagoApiHelper.Templates.Service.txt" },
            { "ServiceImpl", "DamagoApiHelper.Templates.ServiceImpl.txt" },
        };

        private Dictionary<string, string> _templateFiles = new Dictionary<string, string>()
        {
            { "AddRequest", String.Empty },
            { "Controller", String.Empty },
            { "DeleteRequest", String.Empty },
            { "EditRequest", String.Empty },
            { "Entity", String.Empty },
            { "GetRequest", String.Empty },
            { "Repository", String.Empty },
            { "Response", String.Empty },
            { "SearchRequest", String.Empty },
            { "Service", String.Empty },
            { "ServiceImpl", String.Empty },
        };

        private string _projectPath = "org.damago.test";
        private string _entityName = "test";
        private string _EntityName = "Test";
        private string _entityNames = "tests";
        private string _EntityNames = "Tests";

        public TextReplaceService()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (var fileResource in _templateFileResources)
            {
                using (Stream stream = assembly.GetManifestResourceStream(fileResource.Value))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        _templateFiles[fileResource.Key] = reader.ReadToEnd();
                        _templateFiles[fileResource.Key] = _templateFiles[fileResource.Key]
                            .Replace("{{projectPath}}", _projectPath)
                            .Replace("{{entityName}}", _entityName)
                            .Replace("{{EntityName}}", _EntityName)
                            .Replace("{{entityNames}}", _EntityNames)
                            .Replace("{{entityNames}}", _entityNames);
                    }
                }
            }
        }
    }
}
