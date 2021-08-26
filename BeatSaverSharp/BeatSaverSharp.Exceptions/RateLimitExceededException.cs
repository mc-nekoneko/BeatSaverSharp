using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace BeatSaverSharp.Exceptions
{
	public class RateLimitExceededException : Exception
	{
		public RateLimitInfo RateLimit
		{
			get;
		}

		public RateLimitExceededException(RateLimitInfo info)
		{
			RateLimit = info;
		}

		
		public RateLimitExceededException(HttpResponseMessage resp)
		{
			RateLimit = RateLimitInfo.FromHttp(resp) ?? throw new Exception("Could not parse rate limit info");
		}
	}
}
