using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace Simple.Conneg
{
    public class TimeController : ApiController
    {

        public string Get()
        {
            return DateTime.Now.ToLongTimeString();
        }

    }
}
