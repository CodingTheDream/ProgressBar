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
using CommonProgressBar.Settings;
using CommonProgressBar.Converters;

namespace CommonProgressBar.ProgressBarControls.PercentageCircularProgressBar
{
    /// <summary>
    /// Interaction logic for PercentageCircularProgressBar.xaml
    /// </summary>
    public partial class PercentageCircularProgressBar : 
        UserControl, IPercentageProgressBarProperties
    {
        public ProgressBarArc _percentage { get; set; }
        public TextBox PercentFont { get; set; }

        public List<currentjob> currentjobs = new List<currentjob>();

        public PercentageCircularProgressBar()
        {

            InitializeComponent();
            DataContext = new ProgressBarSettings();
            _percentage = new ProgressBarArc();
            PercentFont = new TextBox();
            
            _percentage.Value = PercentNumber;
            _percentage.StrokeThickness = ProgressBarSize / 12;
            _percentage.Width = ProgressBarSize;
            _percentage.Height = ProgressBarSize;

            PercentFont.HorizontalAlignment = HorizontalAlignment.Center;
            PercentFont.VerticalAlignment = VerticalAlignment.Center;
            PercentFont.Foreground = Brushes.DarkGray;
            PercentFont.BorderBrush = Brushes.Transparent;
            PercentFont.FontSize = ProgressBarSize / 12;
            PercentFont.TextAlignment = System.Windows.TextAlignment.Center;


            //currentjob job = new currentjob();
            //job.Name = "体重";
            //job.Value = 150;
            //job.Unit = "kg";
            //currentjobs.Add(job);

            //currentjob job1 = new currentjob();
            //job1.Name = "身高";
            //job1.MinValue = 150;
            //job1.MaxValue = 180;
            //job1.Unit = "cm";
            //currentjobs.Add(job1);




            SetContent();

            Layout.Children.Add(PercentFont);
            Layout.Children.Add(_percentage);
        }
        

        private double _PercentNumber = 0.0;
        public double PercentNumber
        {
            get {
                return _PercentNumber = EndPointValue > StartPointValue ?
                 100*CurrentProgressValue/(EndPointValue-StartPointValue) :
                 100*(1-CurrentProgressValue/(StartPointValue-EndPointValue));
            }
        }

        private double _StartPointValue = 0.0;
        public double StartPointValue
        {
            get{ return _StartPointValue; }
            set{_StartPointValue = value; }
        }

        private double _EndPointValue = 100.0;
        public double EndPointValue
        {
            get { return _EndPointValue; }
            set { _EndPointValue = value;}
        }

        public double CurrentProgressValue
        {
            get
            {
                return ((ProgressBarSettings)DataContext).CurrentProgressValue;
            }
            set
            {
                if (CurrentProgressValue != value)
                {
                    ((ProgressBarSettings)DataContext).CurrentProgressValue = value;

                    _percentage.Value = PercentNumber;
                    SetContent();//UIupdate
                }
            }
        }

        public bool ShowCurrentProgressValue
        {
            get
            {
                return ((ProgressBarSettings)DataContext).ShowCurrentProgressValue;
            }
            set
            {
                ((ProgressBarSettings)DataContext).ShowCurrentProgressValue = value;
            }
        }

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

                _percentage.Width = ProgressBarSize;
                _percentage.Height = ProgressBarSize;
                _percentage.StrokeThickness = ProgressBarSize / 12;
                PercentFont.FontSize = ProgressBarSize/12;//UI update
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
                lock(this)
                {
                    ((ProgressBarSettings)DataContext).TopicFontSize = value;
                }
            }
        }

     
    } 

        
 

    public class ProgressBarArc : Shape
    {

       public ProgressBarArc()
        {

            Brush myGreenBrush = new SolidColorBrush(Color.FromArgb(255, 6, 176, 37));
            myGreenBrush.Freeze();

            this.Stroke = myGreenBrush;

            this.Fill = Brushes.Transparent;
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;

        }

       public double Value
       {
           get { return (double)GetValue(ValueProperty); }
           set { SetValue(ValueProperty, value); }
       }
        
        
        // DependencyProperty - Value (0 - 100)
        private static FrameworkPropertyMetadata valueMetadata =
               new FrameworkPropertyMetadata(
                   0.0,     // Default value
                   FrameworkPropertyMetadataOptions.AffectsRender,
                   null,    // Property changed callback
                   new CoerceValueCallback(CoerceValue));   // Coerce value callback

       public static readonly DependencyProperty ValueProperty =
           DependencyProperty.Register("Value", typeof(double), typeof(ProgressBarArc), valueMetadata);

       private static object CoerceValue(DependencyObject depObj, object baseVal)
       {
           double val = (double)baseVal;
           val = Math.Min(val, 99.999);
           val = Math.Max(val, 0.0);
           return val;
       }

       protected override Geometry DefiningGeometry
       {
           get
           {
               double startAngle = 90.0;
               double endAngle = 90.0 - ((Value / 100.0) * 360.0);

               double maxWidth = Math.Max(0.0, RenderSize.Width - StrokeThickness);
               double maxHeight = Math.Max(0.0, RenderSize.Height - StrokeThickness);

               double xStart = maxWidth / 2.0 * Math.Cos(startAngle * Math.PI / 180.0);
               double yStart = maxHeight / 2.0 * Math.Sin(startAngle * Math.PI / 180.0);

               double xEnd = maxWidth / 2.0 * Math.Cos(endAngle * Math.PI / 180.0);
               double yEnd = maxHeight / 2.0 * Math.Sin(endAngle * Math.PI / 180.0);

               StreamGeometry geom = new StreamGeometry();
               using (StreamGeometryContext ctx = geom.Open())
               {
                   ctx.BeginFigure(
                       new Point((RenderSize.Width / 2.0) + xStart,
                                 (RenderSize.Height / 2.0) - yStart),
                       true,   // Filled
                       false);  // Closed
                   ctx.ArcTo(
                       new Point((RenderSize.Width / 2.0) + xEnd,
                                 (RenderSize.Height / 2.0) - yEnd),
                       new Size(maxWidth / 2.0, maxHeight / 2),
                       0.0,     // rotationAngle
                       (startAngle - endAngle) > 180,   // greater than 180 deg?
                       SweepDirection.Clockwise,
                       true,    // isStroked
                       false);
               }

               return geom;
           }
       }

    }
}
