using Autofac;
using PaperClip.Neuron.Config;
using PaperClip.Neuron.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Autofac;

namespace PaperClip.TopShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var builder = new ContainerBuilder();

                builder.RegisterModule<IoCModule>();
                var container = builder.Build();

                HostFactory.Run(
                        configuration =>
                        {
                            configuration.UseAutofacContainer(container);

                            configuration.Service<PaperClipService>(
                            service =>
                               {
                                   service.ConstructUsingAutofacContainer();
                                   service.WhenStarted(x => x.Start());
                                   service.WhenStopped(x => x.Stop());
                               });

                            configuration.RunAsPrompt();

                            configuration.SetServiceName("ASimpleService");
                            configuration.SetDisplayName("A Simple Service");
                            configuration.SetDescription("Don't Code Tired Demo");
                        });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
