using Autofac;
using PaperClip.Neuron.Config;
using PaperClip.Neuron.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperClip.Neuron.IoC
{
    public class PaperClipNeuronModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Setting>().As<ISetting>();
            builder.RegisterType<PaperWorkNeuron>().As<IPaperWorkNeuron>();
            base.Load(builder);
        }
    }
}
