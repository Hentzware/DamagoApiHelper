using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DamagoApiHelper.Models;

namespace DamagoApiHelper.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly ITextReplaceService _textReplaceService;
        private readonly Endpoint _endpoint;

        public EndpointService(ITextReplaceService textReplaceService, Endpoint endpoint)
        {
            _textReplaceService = textReplaceService;
            _endpoint = endpoint;
        }

        public void AddAddRequest()
        {
            if (File.Exists(_endpoint.AddRequestFilePath))
            {
                File.Delete(_endpoint.AddRequestFilePath);
            }

            File.Create(_endpoint.AddRequestFilePath);
            File.WriteAllText(_endpoint.AddRequestFilePath, "");
        }

        public void AddController()
        {
        }

        public void AddDeleteRequest()
        {
        }

        public void AddEditRequest()
        {
        }

        public void AddGetRequest()
        {
        }

        public void AddRepository()
        {
        }

        public void AddResponse()
        {
        }

        public void AddSearchRequest()
        {
        }

        public void AddService()
        {
        }

        public void AddServiceImpl()
        {
        }

        public void RemoveAddRequest()
        {
        }

        public void RemoveController()
        {
        }

        public void RemoveDeleteRequest()
        {
        }

        public void RemoveEditRequest()
        {
        }

        public void RemoveGetRequest()
        {
        }

        public void RemoveRepository()
        {
        }

        public void RemoveResponse()
        {
        }

        public void RemoveSearchRequest()
        {
        }

        public void RemoveService()
        {
        }

        public void RemoveServiceImpl()
        {
        }
    }
}
