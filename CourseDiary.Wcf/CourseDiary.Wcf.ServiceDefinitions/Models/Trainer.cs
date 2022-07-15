using System;
using System.Runtime.Serialization;

namespace CourseDiary.Wcf.ServiceDefinitions.Models
{
    [DataContract]
    public class Trainer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
    }
}
