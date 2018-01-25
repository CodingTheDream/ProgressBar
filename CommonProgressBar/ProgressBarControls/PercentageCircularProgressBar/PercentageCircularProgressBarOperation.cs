using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProgressBar.GlobalTypes;


namespace CommonProgressBar.ProgressBarControls.PercentageCircularProgressBar
{

    public partial class PercentageCircularProgressBar : IProgressBarOperation
        {

        private List<currentjob> currentjobs = new List<currentjob>();

        double temptest = 0;
            public void Update()
            {
            
                CurrentProgressValue++;//Only for test
                                       //CurrentProgressValue--;
                UpdateJob("体重", temptest++, "kg");
                ProgressBarArc.Value = PercentNumber;
                SetContent();//UIupdate
             

        }

            public void Update(double progress)
            {
                CurrentProgressValue = progress;
            }

        private void SetContent()
        {
            if (ShowCurrentProgressValue == false)
            {
                TextBox.Text = string.Format("{0}%", PercentNumber);
            }
            else if (ShowCurrentProgressValue == true)
            {
                String temp = string.Format("{0}%\n{1}",
                  PercentNumber,
                  CurrentProgressValue);

                foreach (currentjob job in currentjobs)
                {
                    if (job.Value != null)
                    {
                        temp = string.Format("{0}\n{1}{2}{3}",
                            temp,
                            job.Name,
                            job.Value,
                            job.Unit
                        );
                    }
                    else if (job.Value == null &&
                             job.MinValue != null &&
                             job.MaxValue != null
                        )
                    {
                        temp = string.Format("{0}\n{1}{2}--{3}{4}", temp,
                                            job.Name,
                                            job.MinValue,
                                            job.MaxValue,
                                            job.Unit
                        );
                    }
                }

                TextBox.Text = temp;
            }

        }
        
        public void UpdateJob(string name, double value, string unit)
        {
            bool IsJobExist = false;
            currentjob job = new currentjob();
            job.Name = name;
            job.Value = value;
            job.Unit = unit;

            for (int i = 0; i < currentjobs.Count; i++)
            {
                if (currentjobs[i].Name.Equals(name))
                {
                    currentjobs[i] = job;
                    IsJobExist = true;
                    break;
                }
            }

            if(!IsJobExist) currentjobs.Add(job);
        }

        public void UpdateJob(string name, double min, double max, string unit)
        {
            bool IsJobExist = false;
            currentjob job = new currentjob();
            job.Name = name;
            job.MinValue = min;
            job.MaxValue = max;
            job.Unit = unit;

            for (int i = 0; i < currentjobs.Count; i++)
            {
                if (currentjobs[i].Name.Equals(name))
                {
                    currentjobs[i] = job;
                    IsJobExist = true;
                    break;
                }
            }

            if (!IsJobExist) currentjobs.Add(job);
        }

    }
    
}
