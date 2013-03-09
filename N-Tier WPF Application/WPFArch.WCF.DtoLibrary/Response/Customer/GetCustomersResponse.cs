using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Response.Customer
{
    [DataContract]
    public class GetCustomersResponse
    {
        [DataMember]
        public List<CustomerDto> Customers { get; set; }
    }
}