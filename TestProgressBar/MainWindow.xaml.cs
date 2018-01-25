using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CommonProgressBar;
using CommonProgressBar.GlobalTypes;
using CommonProgressBar.ProgressBarControls.CircularProgressBar;
using CommonProgressBar.ProgressBarControls.PercentageCircularProgressBar;
using CommonProgressBar.ProgressBarList;

namespace TestProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IProgressBarListOperation progressBarList = new ProgressBarList();
            ProgressBarList.Children.Add((UserControl)progressBarList);
            var progressBar = progressBarList.Add(ProgressBarType.CIRCULAR_PERCENTAGE_PROGRESS_BAR, "LL1 Pumping");
            progressBar.TopicFontSize = 18;
            progressBar.ProgressBarSize = 120;

            

            new Task(() => {
                Thread.Sleep(2000);
                Dispatcher.Invoke(() => progressBarList.Add(ProgressBarType.CIRCULAR_PERCENTAGE_PROGRESS_BAR, "LL1 Mapping"));
                new Task(() => {
                    Thread.Sleep(2000);
                    Dispatcher.Invoke(() => progressBarList.Add(ProgressBarType.CIRCULAR_PERCENTAGE_PROGRESS_BAR, "LL2 Mapping"));
                    new Task(() => { Thread.Sleep(5000); Dispatcher.Invoke(() => progressBarList.Remove("LL1 Mapping"));
                    }).Start();}).Start();
            }).Start();


        }
    }
}
