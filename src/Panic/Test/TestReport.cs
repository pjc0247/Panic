using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panic.Test
{
    public class TestReport
    {
        public IEnumerable<SingleTestResult> All { get; private set; }

        public IEnumerable<SingleTestResult> Passed
        {
            get
            {
                return All.Where(x => x.Result == TestResult.Passed);
            }
        }
        public IEnumerable<SingleTestResult> Failed
        {
            get
            {
                return All.Where(x => x.Result == TestResult.Failed);
            }
        }
        public IEnumerable<SingleTestResult> Marked
        {
            get
            {
                return All.Where(x => x.Result == TestResult.Marked);
            }
        }
        public IEnumerable<SingleTestResult> Skipped
        {
            get
            {
                return All.Where(x => x.Result == TestResult.Skipped);
            }
        }
    }
}
