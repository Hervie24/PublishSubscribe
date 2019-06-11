using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishSubscribe
{
	public class Subscriber
	{
		public Subscriber()
		{

		}
		public string[] topics = new string[2];
		public Queue<Message> myMessage = new Queue<Message>();
		public void Listen(string newTopic, int index)
		{
			topics[index] = newTopic;

		}

		public void Print()
		{

			for (int i = 0; i < topics.Length; i++)
			{
				while (myMessage.Count != 0)
				{
					Message messageTobeSend = myMessage.Dequeue();
					Console.WriteLine("Topic: " + messageTobeSend.topic + "\n" + "Topic description:"  + messageTobeSend.topicDescription);

				}
			}
		}
	}
}
