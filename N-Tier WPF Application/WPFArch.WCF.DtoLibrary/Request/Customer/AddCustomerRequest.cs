using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Request.Customer
{
    [DataContract]
    public class AddCustomerRequest
    {
        [DataMember]
        public CustomerDto CustomerDto { get; set; }
    }
}