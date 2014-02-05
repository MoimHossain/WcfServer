WcfServer
=========

A handy class to host and consume WCF service with basic net tcp or ws http binding.

The class "WcfService" is the main class that encapsulates all the details and allows users to host 
any POCO classes (with a service contract) as WCF and create client side proxies for  them to invoke.

A typical way to host a service is as follows

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
                    

This above code hosts the MyService class as a WCF service on a given port (8789) with a NetTcpBinding.

Once this service is hosted it can be invoked from a client applicatiojn using the following sample code

                using (var wcf = 
                    WcfService.DefaultFactory.CreateChannel<IWcf>(Environment.MachineName, 8789, (t) => { return "MyService"; }, "WcfServices"))
                {
                    var result = wcf.Client.Greet("Moim");

                    Console.WriteLine(result);
                }
                
That's it.
