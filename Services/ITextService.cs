using System.Collections.Generic;

namespace DamagoApiHelper.Services;

public interface ITextService
{
    string ReplaceText(string template, Dictionary<string, string> replacementDictionary);
}