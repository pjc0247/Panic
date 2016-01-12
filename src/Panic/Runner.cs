using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panic
{
    using Panic.Client;
    using Panic.Protocol.Marshal;
    using Panic.Test.Template;

    public class Runner<T>
        where T : IClient
    {
        public static Task ExecuteScenario(int coWorkers, int iteration)
        {
            return null;
        }

        public Task ExecuteScneario()
        {
            return null;
        }
        public Task ExecuteSingle(TestTemplate template)
        {
            return Task.Run(() =>
            {
                // fixme
                var client = (T)Activator.CreateInstance(
                    typeof(T),
                    "http://localhost:4567", new JsonSerializer());

                var response = client.SendPacket(template.Request);

                Console.WriteLine(response);
            });
        }
    }
}
