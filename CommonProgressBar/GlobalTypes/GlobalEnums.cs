using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProgressBar.GlobalTypes
{
    public enum ProgressBarType
    {
        CIRCULAR_PROGRESS_BAR,
        CIRCULAR_PERCENTAGE_PROGRESS_BAR
    }

    public struct currentjob
    {
        public string Name;
        public double? Value;
        public double? MaxValue;
        public double? MinValue;
        public string Unit;
    }

}
