using System.Runtime.Serialization;

namespace CourseDiary.Wcf.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
    
}
