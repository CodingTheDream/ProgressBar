
using CommonProgressBar.GlobalTypes;
using CommonProgressBar.ProgressBarControls;

namespace CommonProgressBar.ProgressBarList
{
    public interface IProgressBarListOperation
    {
        IProgressBarProperties Add(ProgressBarType type, string topic);
        void Remove(string topic);
        void Update(string topic, double progress);
    }
}
