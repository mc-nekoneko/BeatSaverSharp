using System.Runtime.CompilerServices;

namespace BeatSaverSharp.Exceptions
{
	
	
	public class InvalidPartialHashException : InvalidPartialException
	{
		public string Hash
		{
			get;
		}

		public InvalidPartialHashException(string hash)
		{
			Hash = hash;
		}

		public InvalidPartialHashException(string hash, string message)
			: base(message)
		{
			Hash = hash;
		}
	}
}
