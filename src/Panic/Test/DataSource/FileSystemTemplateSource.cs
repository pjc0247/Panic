using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Panic.Test.DataSource
{
    using Panic.Test.Template;

    public class FileSystemTemplateSource : ITemplateSource
    {
        public static List<string> LookupPath { get; private set; }

        static FileSystemTemplateSource()
        {
            LookupPath = new List<string>()
            {
                ".\\",
                "templates\\"
            };
        }

        public Task<TestTemplate> LoadTemplate(string path)
        {
            return Task.Run(() =>
            {
                var json = File.ReadAllText(path);
                var obj = JObject.Parse(json);

                return new TestTemplate(
                    obj["request"].ToString(), obj["response"].ToString());
            });
        }
    }
}