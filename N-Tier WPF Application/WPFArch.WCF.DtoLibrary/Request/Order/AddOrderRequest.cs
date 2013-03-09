using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Request.Order
{
    [DataContract]
    public class AddOrderRequest
    {
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public OrderDto OrderDto { get; set; }
    }
}