using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DamagoApiHelper.Services
{
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
}
