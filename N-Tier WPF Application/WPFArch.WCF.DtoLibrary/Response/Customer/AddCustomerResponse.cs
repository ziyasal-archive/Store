using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Response.Customer
{
    [DataContract]
    public class AddCustomerResponse
    {
        [DataMember]
        public int CustomerID { get; set; }
    }
}