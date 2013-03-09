using System.Runtime.Serialization;

namespace WPFArch.WCF.DtoLibrary
{
    [DataContract]
    public class CustomerDto
    {
        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
    }
}