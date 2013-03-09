using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Request.Order
{
      [DataContract]
    public class DeleteOrderRequest
    {
          [DataMember]
        public int OrderID { get; set; }
    }
}