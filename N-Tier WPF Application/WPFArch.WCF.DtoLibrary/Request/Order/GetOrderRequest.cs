using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Request.Order
{
      [DataContract]
    public class GetOrderRequest
    {
          [DataMember]
        public int OrderID { get; set; }
    }
}