using System;
using CommonProgressBar.GlobalTypes;
using CommonProgressBar.ProgressBarControls;
using CommonProgressBar.ProgressBarControls.CircularProgressBar;
using CommonProgressBar.ProgressBarControls.PercentageCircularProgressBar;
using System.Collections.Generic;
using System.Windows.Threading;

namespace CommonProgressBar.ProgressBarList
{
    public partial class ProgressBarList : IProgressBarListOperation
    {
        private DispatcherTimer animationTimer;
        private Dictionary<string, IProgressBarProperties> progressBars = new Dictionary<string, IProgressBarProperties>();
        private Dictionary<string, IPercentageProgressBarProperties> PercentageProgressBars = new Dictionary<string, IPercentageProgressBarProperties>();

        private Dictionary<string, double> progressBarUpdate = new Dictionary<string, double>();
        public IProgressBarProperties Add(ProgressBarType type, string topic)
        {
            IProgressBarProperties progressBar = null;
            IPercentageProgressBarProperties pprogressBar = null;
            if (progressBars.ContainsKey(topic))
            {
                throw new Exception(string.Format("Duplicated work topic: {topic}"));
            }
            switch (type)
            {
                case ProgressBarType.CIRCULAR_PROGRESS_BAR:
                    progressBar = new CircularProgressBar();
                    break;
                case ProgressBarType.CIRCULAR_PERCENTAGE_PROGRESS_BAR:
                    //create percentage circular bar
                    pprogressBar = new PercentageCircularProgressBar();
                    //               progressBarUpdate[topic] = ((IPercentageProgressBarProperties)progressBar).CurrentProgressValue;
                    pprogressBar.Topic = topic;
                    PercentageProgressBars[topic] = pprogressBar;
                    AddProgressBarToGUI(pprogressBar);
                    return pprogressBar;
            }
            progressBar.Topic = topic;
            progressBars[topic] = progressBar;
            AddProgressBarToGUI(progressBar);
            return progressBar;
        }

        public void Remove(string topic)
        {
            if (!progressBars.ContainsKey(topic) && !PercentageProgressBars.ContainsKey(topic))
            {
                throw new Exception(string.Format("Work Topic: {topic} Not Exist"));
            }
            if (progressBars.ContainsKey(topic))
            {
                RemoveProgressBarFromGUI(progressBars[topic]);
                progressBars.Remove(topic);
            }
            if (PercentageProgressBars.ContainsKey(topic))
            {
                RemoveProgressBarFromGUI(PercentageProgressBars[topic]);
                PercentageProgressBars.Remove(topic);
            }
        }

        public void Update(string topic, double progress)
        {
            progressBarUpdate[topic] = progress;
        }

        private void InitializeTimer()
        {
            animationTimer = new DispatcherTimer(
                DispatcherPriority.ContextIdle, Dispatcher);
            animationTimer.Interval = new TimeSpan(0, 0, 0, 0, 25);
            animationTimer.Tick += UpdateProgressBars;
            animationTimer.Start();
        }

        private void UpdateProgressBars(object sender, EventArgs e)
        {
            foreach (var progressBar in progressBars.Values)
            {
                if (progressBar is CircularProgressBar)
                {
                    ((IProgressBarOperation)progressBar).Update();
                }
                else
                {
                    ((IProgressBarOperation)progressBar).Update(progressBarUpdate[progressBar.Topic]);
                }
            }
            foreach (var PercentageProgressBar in PercentageProgressBars.Values)
            {
                if (PercentageProgressBar is PercentageCircularProgressBar)
                {
                    ((IProgressBarOperation)PercentageProgressBar).Update();
                }
                else
                {
                    ((IProgressBarOperation)PercentageProgressBar).Update(progressBarUpdate[PercentageProgressBar.Topic]);
                }
            }
        }
    }
}
