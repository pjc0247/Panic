using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace Panic.Test.Template
{
    public class TestTemplate
    {
        public string RawRequest { get; private set; }
        public string RawResponse { get; private set; }

        public JObject Request { get; private set; }
        public JObject Response { get; private set; }
        
        public TestTemplate(string rawRequest, string rawResponse)
        {
            RawRequest = rawRequest;
            RawResponse = rawResponse;
            Request = JObject.Parse(rawRequest);
            Response = JObject.Parse(rawResponse);
        }
    }
}
