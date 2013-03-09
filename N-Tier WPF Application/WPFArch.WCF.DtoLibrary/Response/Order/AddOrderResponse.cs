using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Response.Order
{
    [DataContract]
    public class AddOrderResponse
    {
        [DataMember]
        public int OrderID { get; set; }
    }
}