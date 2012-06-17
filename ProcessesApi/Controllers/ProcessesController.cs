using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProcessesApi.Models.Representations;

namespace ProcessesApi.Controllers
{

    public class ProcessesController : ApiController
    {

        public IEnumerable<ProcessRepModel> Get()
        {
            return Process
                .GetProcesses()
                .Select(p => new ProcessRepModel(p));
        }

        public IEnumerable<ProcessRepModel> Get(string name)
        {
            return Process
                .GetProcessesByName(name)
                .Select(p => new ProcessRepModel(p));
        }

        public ProcessRepModel Get(int id)
        {
            try
            {
                var proc = Process.GetProcessById(id);
                return new ProcessRepModel(proc);
            }
            catch (ArgumentException)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }
    }
}