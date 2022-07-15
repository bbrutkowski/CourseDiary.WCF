using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CourseDiary.Wcf.Models
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string Name;
        [DataMember]
        public DateTime BeginDate;
        [DataMember]
        public Trainer Trainer;
        [DataMember]
        public List<Student> Students;
        [DataMember]
        public double PresenceTreshold = 70.0;
        [DataMember]
        public double HomeworkTreshold = 70.0;
        [DataMember]
        public double TestTreshold = 70.0;
    }
}
