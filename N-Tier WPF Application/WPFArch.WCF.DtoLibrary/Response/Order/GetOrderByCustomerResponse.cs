using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Response.Order
{
    [DataContract]
    public class GetOrderByCustomerResponse
    {
        [DataMember]
        public List<OrderDto> Orders { get; set; }
    }
}