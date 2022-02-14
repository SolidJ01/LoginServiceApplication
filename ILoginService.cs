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
        bool LoginUser(string email, string password);
        [OperationContract]
        LoginData LoginHost(string email, string password);
        [OperationContract]
        bool LoginAdmin(string username, string password);
        [OperationContract]
        int CreateUser(string email, string password);
        [OperationContract]
        int CreateHost(string email, string password);

        [OperationContract]
        string GetUserEmail(int id);
        [OperationContract]
        string GetHostEmail(int id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class LoginData
    {
        [DataMember]
        public bool Success { get; set; } = false;
        [DataMember]
        public int? Id { get; set; }
    }
}
