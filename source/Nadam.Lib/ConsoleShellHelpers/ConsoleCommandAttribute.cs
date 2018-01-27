﻿using System;

namespace Nadam.Lib.ConsoleShellHelpers
{
	/// <summary>
	/// Should go to a common lib (Nadam.Lib)
	/// </summary>
	public class CommandShellAttribute : Attribute
	{
		public string[] CommandAliases { get; set; }
		public CommandType CommandType { get; set; }

		public CommandShellAttribute(string _alias, CommandType type = CommandType.Func)
		{
			CommandAliases = new string[1];
			CommandAliases[0] = _alias;
			CommandType = type;
		}

		public CommandShellAttribute(string[] _aliases, CommandType type = CommandType.Func)
		{
			CommandAliases = _aliases;
			CommandType = type;
		}
	}
}
