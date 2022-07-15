using CourseDiary.Wcf.ServiceDefinitions.Interfaces;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace CourseDiary.Wcf.SelfhostServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8090/CourseDiary");
        
            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(ServiceDefinitions), httpUrl);

            //Add a service endpoint
            var binding = new WSHttpBinding();
            host.AddServiceEndpoint(typeof(IUserManagmentService), binding, "Users");
            //host.AddServiceEndpoint(typeof(IAnomalyManagmentService), binding, "Trainer");
            //host.AddServiceEndpoint(typeof(IInspectionManagmentService), binding, "Student");
           // host.AddServiceEndpoint(typeof(IPowerPlantManagmentService), binding, "Course");
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
