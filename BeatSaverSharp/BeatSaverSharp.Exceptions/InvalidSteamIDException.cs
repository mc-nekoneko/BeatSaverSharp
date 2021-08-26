using System;
using System.Runtime.CompilerServices;

namespace BeatSaverSharp.Exceptions
{
	public class InvalidSteamIDException : Exception
	{
		public string SteamID
		{
			get;
		}

		public InvalidSteamIDException(string steamID)
		{
			SteamID = steamID;
		}
	}
}
