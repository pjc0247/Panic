using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Panic.Protocol.Marshal
{
    public class JsonSerializer : ISerializer
    {
        public JObject Deserialize(byte[] data)
        {
            var json = Encoding.UTF8.GetString(data);

            return JObject.Parse(json);
        }

        public byte[] Serialize(JObject obj)
        {
            return Encoding.UTF8.GetBytes(obj.ToString());
        }
    }
}
