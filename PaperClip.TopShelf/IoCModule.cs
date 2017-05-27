using Autofac;
using PaperClip.Neuron.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperClip.TopShelf
{
    class IoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<PaperClipNeuronModule>();
            builder.RegisterType<PaperClipService>();
            base.Load(builder);
        }
    }
}
