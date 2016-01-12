using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panic.Test
{
    public class TestRule
    {
        public virtual TestResult OnContractFailure() => TestResult.Failed;

        public virtual TestResult OnFieldNotExpected() => TestResult.Passed;
        public virtual TestResult OnFieldMissing() => TestResult.Failed;
    }
}
