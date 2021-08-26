using System.Runtime.CompilerServices;

namespace BeatSaverSharp.Exceptions
{
	
	
	public class InvalidPartialKeyException : InvalidPartialException
	{
		public string Key
		{
			get;
		}

		public InvalidPartialKeyException(string key)
		{
			Key = key;
		}

		public InvalidPartialKeyException(string key, string message)
			: base(message)
		{
			Key = key;
		}
	}
}
