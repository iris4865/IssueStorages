using Akka.Actor;
using System;

namespace AkkaSelectionNettyEnvClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                ActorSystem system = ActorSystem.Create("Client");

                var actor = system.ActorSelection("akka.tcp://Server@192.168.100.99:8083/user/HelloActor")
                    .ResolveOne(TimeSpan.FromSeconds(10))
                    .Result;

                actor.Tell("Hello");

                system.Terminate();
            }
            catch(Exception)
            {

            }
        }
    }
}
