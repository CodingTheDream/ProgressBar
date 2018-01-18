using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProgressBar.ProgressBarControls
{
    public interface IPercentageProgressBarProperties : IProgressBarProperties
    {
        double StartPointValue { get; set; }
        double EndPointValue { get; set; }
        double CurrentProgressValue { get; set; }
        bool ShowCurrentProgressValue { get; set; }
        double PercentNumber { get; }



    }
}
