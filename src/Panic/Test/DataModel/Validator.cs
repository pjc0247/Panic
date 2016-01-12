using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Panic.Test.DataModel
{
    internal class Validator
    {
        public static void Validate()
        {
            var contracts = Assembly.GetExecutingAssembly().GetTypes().
                Where(x => x.IsSubclassOf(typeof(DataModelContract)));
            
            foreach (var type in contracts)
            {
                var contract = Activator.CreateInstance(type);
                var fields =
                    Assembly.GetEntryAssembly().GetTypes().
                        SelectMany(x => x.GetFields(BindingFlags.Public | BindingFlags.Instance)).
                        Where(x => x.GetCustomAttribute(type) != null);

                foreach(var field in fields)
                {
                    ((DataModelContract)contract).Validate(field);
                }
            }
        }
    }
}
