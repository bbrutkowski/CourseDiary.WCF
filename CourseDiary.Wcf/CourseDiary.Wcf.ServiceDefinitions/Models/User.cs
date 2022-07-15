using System.Runtime.Serialization;

namespace CourseDiary.Wcf.ServiceDefinitions.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}
