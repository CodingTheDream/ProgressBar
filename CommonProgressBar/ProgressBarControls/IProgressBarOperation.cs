using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProgressBar.ProgressBarControls
{
    public interface IProgressBarOperation
    {
        void Update();
        void Update(double progress);
    }
}
