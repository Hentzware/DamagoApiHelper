using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamagoApiHelper.Services
{
    public interface ITextReplaceService
    {
        string GetAddRequestText();

        string GetDeleteRequestText();

        string GetSearchRequestText();

        string GetEditRequestText();

        string GetServiceText();

        string GetServiceImplText();

        string GetControllerText();

        string GetGetRequestText();

        string GetRepositoryText();
    }
}
