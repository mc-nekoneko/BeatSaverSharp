using System;
using System.Runtime.CompilerServices;

namespace BeatSaverSharp.Exceptions
{
	public class InvalidPartialException : Exception
	{
		public InvalidPartialException()
		{
		}

		
		public InvalidPartialException(string message)
			: base(message)
		{
		}
	}
}
