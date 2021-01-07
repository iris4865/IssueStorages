using Akka.Actor;
using System;

namespace AkkaSelectionNettyEnvServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("Server");

            system.ActorOf(Props.Create(() => new HelloActor()), "HelloActor");

            system.WhenTerminated.Wait();
        }
    }

    public class HelloActor : ReceiveActor
    {
        public HelloActor()
        {
            Receive<string>(value =>
            {
                Console.WriteLine(value);
            });
        }
    }
}
