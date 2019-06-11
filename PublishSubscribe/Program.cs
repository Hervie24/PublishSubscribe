using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishSubscribe
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("Enter subscriber name:");
			var subscriberName1 = Console.ReadLine();
			Console.WriteLine("Enter topics:");
			var topic1 = Console.ReadLine();
			Console.WriteLine("Enter topic description:");
			var topicDescription1 = Console.ReadLine();

			Console.WriteLine("Enter subscriber name:");
			var subscriberName2 = Console.ReadLine();
			Console.WriteLine("Enter topics:");
			var topic2 = Console.ReadLine();
			Console.WriteLine("Enter topic description:");
			var topicDescription2 = Console.ReadLine();


			Publisher publisher1 = new Publisher();
			Publisher publisher2 = new Publisher();

			Subscriber subscriber1 = new Subscriber();
			Subscriber subscriber2 = new Subscriber();

			FakeServer Server = new FakeServer();

			Message firstMessage = new Message();
			firstMessage.topic = topic1;
			firstMessage.topicDescription = topicDescription1;

			Message secondMessage = new Message();
			secondMessage.topic = topic2;
			secondMessage.topicDescription = topicDescription2;

			publisher1.Send(firstMessage, Server);
			publisher2.Send(secondMessage, Server);

			subscriber1.Listen(topic1, 0);
			//AnimalLover.Listen("Cats", 1);

			subscriber2.Listen(topic2, 0);

			Server.subscribers[0] = subscriber1;
			Server.subscribers[1] = subscriber2;

			Server.Forward();

			Console.WriteLine("\n");
			Console.WriteLine("================================");

			Console.WriteLine($"{subscriberName1} has subscribed to the following message");
			subscriber1.Print();

			Console.WriteLine("\n");
			Console.WriteLine("================================");

			Console.WriteLine($"{subscriberName2} has subscribed to the following message");
			subscriber2.Print();
			Console.ReadKey();
		}
	}
}
