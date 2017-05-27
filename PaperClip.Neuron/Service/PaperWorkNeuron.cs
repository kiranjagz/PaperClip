using PaperClip.Neuron.Config;
using PaperClip.Neuron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PaperClip.Neuron.Service
{
    public class PaperWorkNeuron : IPaperWorkNeuron
    {
        private ISetting _setting;
        private System.Timers.Timer _timer;
        private TimeKeeperEntities _timeKeeperEntities;

        public PaperWorkNeuron(ISetting setting)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            _setting = setting;
        }

        public bool CancelDailyPaper()
        {
            return true;
        }

        public bool DeliverDailyPaper()
        {
            _timer = new System.Timers.Timer(600000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;
            return true;
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            using (_timeKeeperEntities = new TimeKeeperEntities())
            {
                var random = new Random().Next(5000).ToString();
                var code = $"{_setting.EventKey}.{random}";
                var dateTime = DateTime.Now;
                var guid = Guid.NewGuid();

                var calendarEvent = new CalendarEvent()
                {
                    DateCreated = dateTime,
                    EventKey = guid,
                    Code = code
                };

                _timeKeeperEntities.CalendarEvents.Add(calendarEvent);
                var save = _timeKeeperEntities.SaveChanges();
            }
        }
    }
}
