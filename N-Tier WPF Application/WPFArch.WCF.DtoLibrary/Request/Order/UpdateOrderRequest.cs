using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Request.Order
{
    [DataContract]
    public class UpdateOrderRequest
    {
        [DataMember]
        public OrderDto OrderDto { get; set; }
    }
}