using System.Collections.Generic;

namespace DamagoApiHelper.Services;

public class TextService : ITextService
{
    public string ReplaceText(string template, Dictionary<string, string> replacementDictionary)
    {
        foreach (var replacementKeyValuePair in replacementDictionary)
        {
            template = template.Replace(replacementKeyValuePair.Key, replacementKeyValuePair.Value);
        }

        return template;
    }
}