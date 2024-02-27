using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamagoApiHelper.Services
{
    public interface ITextService
    {
        string ReplaceText(string template, Dictionary<string, string> replacementDictionary);
    }
}
