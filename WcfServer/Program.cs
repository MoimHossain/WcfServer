

// No License or anything. Feel free to use it anyway you like. 
// Mentioning the origonal authors name would be greatly appreciated but not necessary at all.

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
