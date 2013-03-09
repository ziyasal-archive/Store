using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Request.Customer
{
    [DataContract]
    public class DeleteCustomerRequest
    {
        [DataMember]
        public int CustomerID { get; set; }
    }
}