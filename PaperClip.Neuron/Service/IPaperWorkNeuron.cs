using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperClip.Neuron.Service
{
    public interface IPaperWorkNeuron
    {
        bool DeliverDailyPaper();

        bool CancelDailyPaper();
    }
}
