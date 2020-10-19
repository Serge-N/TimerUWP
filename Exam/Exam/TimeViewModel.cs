using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Xamarin.Forms;

namespace Exam
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        DateTime dateTime;
        DateTime ExamDate = new DateTime(2020, 11, 10, 06, 30, 00);
        public event PropertyChangedEventHandler PropertyChanged;
        public TimeViewModel()
        {
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
        }


        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DaysLeft"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HoursLeft"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinutesLeft"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SecondsLeft"));
                }
            }
            get
            {
                return dateTime;
            }
        }
        public int DaysLeft => (int)(ExamDate - dateTime).Days;
        public int HoursLeft => ExamDate.Subtract(dateTime).Hours;
        public double MinutesLeft => ExamDate.Subtract(dateTime).Minutes;
        public double SecondsLeft =>  ExamDate.Subtract(dateTime).Seconds;
    }
}
