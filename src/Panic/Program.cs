using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Panic
{
    using Panic.Client.Http;
    using Panic.Test.DataSource;

    class Foo
    {
        //[Panic.Test.DataModel.StringRange(1, 1)]
        [Panic.Test.DataModel.NotNull]
        public string Name;
    }

    class Program
    {
        static async void Foo()
        {
            var http = new HttpClient("http://localhost:4567", new Panic.Protocol.Marshal.JsonSerializer());

            var packet = JObject.Parse(@"
            {
                ""uri"" : ""/test"",
                ""content"" : {
                }
            }
                ");

            await http.SendPacket(packet);
        }
        static async void Bar()
        {
            Runner<HttpClient> a = new Runner<HttpClient>();
            FileSystemTemplateSource b = new FileSystemTemplateSource();
            
            await a.ExecuteSingle(await b.LoadTemplate("test.json"));
        }
        static void Main(string[] args)
        {
            Panic.Test.DataModel.Validator.Validate();

            Foo();
            Bar();

            Console.Read();
        }
    }
}
