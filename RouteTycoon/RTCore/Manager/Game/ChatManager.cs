using System.Collections.Generic;
using System.Linq;

namespace RouteTycoon.RTCore
{
	public class ChatManager
	{
		private List<Chat> chats = new List<Chat>();

		public void AppendChat(Chat c)
		{
			if (chats.Count == 500)
			{
				chats.Remove(chats.First());
				chats.Add(c);
			}
			else
				chats.Add(c);
		}

		public List<Chat> GetChats()
		{
			List<Chat> r = new List<Chat>();

			foreach (var it in chats)
				r.Add(it);

			return r;
		}
	}
}
