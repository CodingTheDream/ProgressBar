using CommonProgressBar.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CommonProgressBar.ProgressBarControls.CircularProgressBar
{
    /// <summary>
    /// Interaction logic for CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar : UserControl, IProgressBarProperties
    {
        public string Topic
        {
            get
            {
                return ((ProgressBarSettings)DataContext).Topic;
            }
            set
            {
                ((ProgressBarSettings)DataContext).Topic = value;
            }
        }
        public int ProgressBarSize
        {
            get
            {
                return ((ProgressBarSettings)DataContext).ProgressBarSize;
            }
            set
            {
                ((ProgressBarSettings)DataContext).ProgressBarSize = value;
            }
        }

        public int TopicFontSize
        {
            get
            {
                return ((ProgressBarSettings)DataContext).TopicFontSize;
            }
            set
            {
                ((ProgressBarSettings)DataContext).TopicFontSize = value;
            }
        }

        #region Constructor
        public CircularProgressBar()
        {
            InitializeComponent();
            DataContext = new ProgressBarSettings();
        }
        #endregion
        
        #region Private Methods

        private void HandleAnimationTick(object sender, EventArgs e)
        {
            SpinnerRotate.Angle = (SpinnerRotate.Angle + 36) % 360;
        }

        private void UpdateProgressBar()
        {
            SpinnerRotate.Angle = (SpinnerRotate.Angle + 36) % 360;
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            const double offset = Math.PI;
            const double step = Math.PI * 2 / 10.0;

            SetPosition(C0, offset, 0.0, step);
            SetPosition(C1, offset, 1.0, step);
            SetPosition(C2, offset, 2.0, step);
        }

        private void SetPosition(Ellipse ellipse, double offset,
            double posOffSet, double step)
        {
            var range = ProgressBarCanvas.ActualWidth * 5 / 12;
            ellipse.SetValue(Canvas.LeftProperty, range
                + Math.Sin(offset + posOffSet * step) * range);

            ellipse.SetValue(Canvas.TopProperty, range
                + Math.Cos(offset + posOffSet * step) * range);
        }
        #endregion
    }
}
