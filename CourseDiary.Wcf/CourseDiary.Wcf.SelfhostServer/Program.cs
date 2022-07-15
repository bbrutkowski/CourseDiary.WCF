using CourseDiary.Wcf.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace CourseDiary.Wcf.SelfhostServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8090/CourseDiary");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(CourseDiaryServiceDefinitions), httpUrl);

            //Add a service endpoint
            var binding = new WSHttpBinding();
            host.AddServiceEndpoint(typeof(ICourseManagmentClient), binding, "Course");
            host.AddServiceEndpoint(typeof(IStudentManagmentClient), binding, "Student");
            host.AddServiceEndpoint(typeof(ITrainerManagmentClient), binding, "Trainer");
            host.AddServiceEndpoint(typeof(IUserManagmentClient), binding, "Users");
            //Enable metadata exchange
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            //Start the Service
            host.Open();
            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press  key to stop");
            Console.ReadLine();
        }
    }
}
