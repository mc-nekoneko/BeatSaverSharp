using System;

namespace BeatSaverSharp.Exceptions
{
	public class UnknownVotingException : Exception
	{
		public RestError RestError
		{
			get;
		}

		public UnknownVotingException(RestError restError)
		{
			RestError = restError;
		}
	}
}
