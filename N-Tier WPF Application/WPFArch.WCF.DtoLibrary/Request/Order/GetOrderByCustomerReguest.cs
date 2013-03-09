using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary.Request.Order
{
    [DataContract]
    public class GetOrderByCustomerReguest
    {
        [DataMember]
        public int CustomerID { get; set; }
    }
}