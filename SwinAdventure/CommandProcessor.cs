using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
	public class CommandProcessor
	{
		private List<Command> _commands;

		public CommandProcessor ()
		{
			 _commands = new List<Command> ();
			LookCommand l = new LookCommand (new string[] { "look" });
			MoveCommand m = new MoveCommand (new string[] { "move" });
			_commands.Add (l);
			_commands.Add (m);
		}

		public string Execute (Player p, string[] text)
		{
			foreach (Command c in _commands) 
			{
				if (c.FirstId == text [0])
					return c.Execute (p, text);
			}
			return null;
		}
	}
}

