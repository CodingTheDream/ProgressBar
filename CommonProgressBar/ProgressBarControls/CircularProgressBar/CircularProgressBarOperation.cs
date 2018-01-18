using System;
using System.Windows.Threading;

namespace CommonProgressBar.ProgressBarControls.CircularProgressBar
{
    public partial class CircularProgressBar : IProgressBarOperation
    {

        public void Update()
        {
            UpdateProgressBar();
        }

        public void Update(double progress)
        {
            throw new NotImplementedException();
        }
    }
}
