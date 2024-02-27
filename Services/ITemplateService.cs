using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamagoApiHelper.Services
{
    public interface ITemplateService
    {
        string LoadAddRequestTemplate();

        string LoadControllerTemplate();

        string LoadDeleteRequestTemplate();

        string LoadEditRequestTemplate();

        string LoadEntityTemplate();

        string LoadGetRequestTemplate();

        string LoadRepositoryTemplate();

        string LoadResponseTemplate();

        string LoadSearchRequestTemplate();

        string LoadServiceTemplate();

        string LoadServiceImplTemplate();
    }
}
