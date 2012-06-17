using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ProcessesApi.Models.Representations
{
    public class ProcessRepModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // other properties

        public ProcessRepModel() { }
        public ProcessRepModel(Process proc)
        {
            Id = proc.Id;
            Name = proc.ProcessName;
            // other properties
        }
    }
}