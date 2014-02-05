

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract(Namespace = "http://bluecieloecm.com/enterpriseservices")]
    public interface IWcf
    {
        [OperationContract]
        string Greet(string name);
    }
}




