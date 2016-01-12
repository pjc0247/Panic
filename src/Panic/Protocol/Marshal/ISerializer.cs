using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace Panic.Protocol.Marshal
{
    public interface ISerializer
    {
        byte[] Serialize(JObject obj);
        JObject Deserialize(byte[] data);
    }
}
