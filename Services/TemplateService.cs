using System.IO;
using System.Reflection;

namespace DamagoApiHelper.Services;

public class TemplateService : ITemplateService
{
    private readonly Assembly assembly = Assembly.GetExecutingAssembly();

    public string LoadTemplate(string templateName)
    {
        var templateFile = $"DamagoApiHelper.Templates.{templateName}.txt";
        return ReadTemplateFile(templateFile);
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