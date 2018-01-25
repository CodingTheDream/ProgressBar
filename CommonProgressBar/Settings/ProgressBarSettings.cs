using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProgressBar.Settings
{
    public class ProgressBarSettings : INotifyPropertyChanged
    {
        private string _topic = "No Topic";
        private int _topicFontSize = 12;
        private int _progressBarSize = 200;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propname)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }

        public string Topic
        {
            get { return _topic; }
            set
            {
                _topic = value;
                OnPropertyChanged("Topic");
            }
        }

        public int ProgressBarSize
        {
            get { return _progressBarSize; }
            set
            {
                _progressBarSize = value;
                OnPropertyChanged("ProgressBarSize");
            }
        }

        public int TopicFontSize
        {
            get { return _topicFontSize; }
            set
            {
                _topicFontSize = value;
                OnPropertyChanged("TopicFontSize");
            }
        }

        #region Percentage Progress Bar Settings
        private double _currentProgressValue = 0.0;
        public double CurrentProgressValue
        {
            get { return _currentProgressValue; }
            set
            {
                _currentProgressValue = value;
                OnPropertyChanged("CurrentProgressValue");
            }
        }

        private bool _showCurrentProgressValue = true;
        public bool ShowCurrentProgressValue
        {
            get { return _showCurrentProgressValue; }
            set
            {
                _showCurrentProgressValue = value;
                OnPropertyChanged("ShowCurrentProgressValue");
            }
        }

        #endregion
    }
}
