using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Request.Customer
{
    [DataContract]
    public class UpdateCustomerRequest
    {
        [DataMember]
        public CustomerDto CustomerDto { get; set; }
    }
}