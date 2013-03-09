using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary
{
    [DataContract]
    public class OrderDto
    {
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
}