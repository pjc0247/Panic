using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Panic.Client.Http
{
    using Panic.Protocol.Marshal;

    public class HttpClient : IClient
    {
        public string Host { get; private set; }
        private ISerializer Serializer { get; set; }

        public HttpClient(string host, ISerializer serializer)
        {
            Host = host;
            Serializer = serializer;
        }

        public async Task<string> SendRaw(string uri, byte[] json)
        {
            System.Net.Http.HttpClient http = new System.Net.Http.HttpClient();

            var content = new ByteArrayContent(json);
            var response = await http.PostAsync(Host + uri, content);

            return await response.Content.ReadAsStringAsync();
        }
        public Task<JObject> SendPacket(JObject packet)
        {
            return Task.Run(async () =>
            {
                var uri = (string)packet["uri"];
                var content = (JObject)packet["content"];

                var response = await SendRaw(uri,
                    Serializer.Serialize(content));

                Console.WriteLine("ASDF");
                Console.WriteLine(response);

                return JObject.Parse(response);
            });
        }
    }
}
