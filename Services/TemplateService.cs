using System.IO;
using System.Reflection;

namespace DamagoApiHelper.Services
{
    public class TemplateService : ITemplateService
    {
        private Assembly assembly = Assembly.GetExecutingAssembly();
        
        public string LoadAddRequestTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.AddRequest.txt");
        }

        public string LoadControllerTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.Controller.txt");
        }

        public string LoadDeleteRequestTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.DeleteRequest.txt");
        }

        public string LoadEditRequestTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.EditRequest.txt");
        }

        public string LoadEntityTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.Entity.txt");
        }

        public string LoadGetRequestTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.GetRequest.txt");
        }

        public string LoadRepositoryTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.Repository.txt");
        }

        public string LoadResponseTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.Response.txt");
        }

        public string LoadSearchRequestTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.SearchRequest.txt");
        }

        public string LoadServiceTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.Service.txt");
        }

        public string LoadServiceImplTemplate()
        {
            return ReadTemplateFile("DamagoApiHelper.Templates.ServiceImpl.txt");
        }

        private string ReadTemplateFile(string templateFile)
        {
            using (var stream = assembly.GetManifestResourceStream(templateFile))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
