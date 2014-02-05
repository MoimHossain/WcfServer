


using Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // use WcfService.Tcp for NetTcp binding or WcfService.Http for WSHttpBinding

                var hosts = WcfService.DefaultFactory.CreateServers(
                    new List<Type> { typeof(MyService) },
                    (t) => { return t.Name; },
                    (t) => { return typeof(IWcf); },
                    "WcfServices",
                    8789,
                    (sender, exception) => { Trace.Write(exception); },
                    (msg) => { Trace.Write(msg); },
                    (msg) => { Trace.Write(msg); },
                    (msg) => { Trace.Write(msg); });

                Console.WriteLine("Server started....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}
