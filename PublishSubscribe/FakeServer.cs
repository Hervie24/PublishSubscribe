using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishSubscribe
{
	public class FakeServer
	{
		public FakeServer()
		{

		}

		public Queue<Message> buffer = new Queue<Message>();
		public Subscriber[] subscribers = new Subscriber[2];
		public void Forward()
		{
			while (buffer.Count != 0)
			{
				Message tempMessage = buffer.Dequeue();
				for (int i = 0; i < subscribers.Length; i++)
				{
					for (int j = 0; j < subscribers[i].topics.Length; j++)
					{
						if (tempMessage.topic == subscribers[i].topics[j])
						{
							subscribers[i].myMessage.Enqueue(tempMessage);
						}

					}
				}

			}
		}
	};
}
