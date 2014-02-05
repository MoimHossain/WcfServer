// No License or anything. Feel free to use it anyway you like. 
// Mentioning the origonal authors name would be greatly appreciated but not necessary at all.
﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract(Namespace = "http://abc.com/enterpriseservices")]
    public interface IWcf
    {
        [OperationContract]
        string Greet(string name);
    }
}




