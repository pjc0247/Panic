using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panic.Test.DataSource
{
    using Panic.Test.Template;

    public interface ITemplateSource
    {
        Task<TestTemplate> LoadTemplate(string name);
    }
}
