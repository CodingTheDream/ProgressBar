using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProgressBar.ProgressBarControls
{
    public interface IProgressBarProperties
    {
        string Topic { get; set; }
        int ProgressBarSize { get; set; }
        int TopicFontSize { get; set; }
    }
}
