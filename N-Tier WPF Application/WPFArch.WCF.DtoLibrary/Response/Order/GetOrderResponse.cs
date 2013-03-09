using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Response.Order
{
    [DataContract]
    public class GetOrderResponse
    {
        [DataMember]
        public OrderDto OrderDto { get; set; }
    }
}