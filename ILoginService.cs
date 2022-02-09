using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        LoginData LoginUser(string username, string password);
        [OperationContract]
        bool LoginAdmin(string username, string password);
        [OperationContract]
        bool CreateUser(string username, string password, string role);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class LoginData
    {
        [DataMember]
        public bool LoggedIn { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}
