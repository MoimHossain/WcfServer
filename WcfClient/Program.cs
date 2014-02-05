


// No License or anything. Feel free to use it anyway you like. 
// Mentioning the origonal authors name would be greatly appreciated but not necessary at all.﻿

using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // use WcfService.Tcp for NetTcp binding or WcfService.Http for WSHttpBinding

                using (var wcf = 
                    WcfService.DefaultFactory.CreateChannel<IWcf>(Environment.MachineName, 8789, (t) => { return "MyService"; }, "WcfServices"))
                {
                    var result = wcf.Client.Greet("Moim");

                    Console.WriteLine(result);
                }
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
