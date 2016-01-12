using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panic.Test
{
    public class SingleTestResult
    {
        public TestResult Result { get; private set; }
        public int Duration { get; private set; }
    }
}