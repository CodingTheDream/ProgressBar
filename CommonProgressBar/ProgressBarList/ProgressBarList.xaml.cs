using System;
using System.Windows.Controls;
using CommonProgressBar.ProgressBarControls;

namespace CommonProgressBar.ProgressBarList
{
    /// <summary>
    /// Interaction logic for ProgressBarList.xaml
    /// </summary>
    public partial class ProgressBarList : UserControl
    {
        public ProgressBarList()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void AddProgressBarToGUI(IProgressBarProperties progressBar)
        {
            UserControl userControl = (UserControl)progressBar;
            DockPanel.SetDock(userControl, Dock.Left);
            ProgressBarDockPanel.Children.Add(userControl);
        }

        private void AddProgressBarToGUI(IPercentageProgressBarProperties percentageProgressBar)
        {
            UserControl userControl = (UserControl)percentageProgressBar;
            DockPanel.SetDock(userControl, Dock.Left);
            ProgressBarDockPanel.Children.Add(userControl);
        }

        private void RemoveProgressBarFromGUI(IPercentageProgressBarProperties percentageProgressBar)
        {
            ProgressBarDockPanel.Children.Remove((UserControl)percentageProgressBar);
        }

        private void RemoveProgressBarFromGUI(IProgressBarProperties progressBar)
        {
            ProgressBarDockPanel.Children.Remove((UserControl)progressBar);
        }
    }
}
