using PaperClip.Neuron.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace PaperClip.TopShelf
{
    public class PaperClipService
    {
        private IPaperWorkNeuron _paperWorkNeuron;

        public PaperClipService(IPaperWorkNeuron paperWorkNeuron)
        {
            _paperWorkNeuron = paperWorkNeuron;
        }

        public bool Start()
        {
            return _paperWorkNeuron.DeliverDailyPaper();
        }

        public bool Stop()
        {
            return _paperWorkNeuron.CancelDailyPaper();
        }
    }
}
