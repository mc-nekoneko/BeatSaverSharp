using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace BeatSaverSharp
{
	public struct RateLimitInfo
	{
		public int Remaining
		{
			
			get;
		}

		public DateTime Reset
		{
			
			get;
		}

		public int Total
		{
			
			get;
		}

		public RateLimitInfo(int remaining, DateTime? reset, int total)
		{
			Remaining = remaining;
			Reset = reset ?? throw new ArgumentNullException("reset");
			Total = total;
		}

		
		internal static RateLimitInfo? FromHttp(HttpResponseMessage resp)
		{
			if (resp == null)
			{
				throw new ArgumentNullException("resp");
			}
			DateTime? reset = null;
			if (resp.Headers.TryGetValues("Rate-Limit-Remaining", out var values))
			{
				string text = values.FirstOrDefault();
				if (text != null)
				{
					if (int.TryParse(text, out var result))
					{
						int remaining = result;
						if (resp.Headers.TryGetValues("Rate-Limit-Total", out var values2))
						{
							string text2 = values2.FirstOrDefault();
							if (text2 != null)
							{
								if (int.TryParse(text2, out var result2))
								{
									int total = result2;
									if (resp.Headers.TryGetValues("Rate-Limit-Reset", out var values3))
									{
										string text3 = values3.FirstOrDefault();
										if (text3 != null)
										{
											if (!ulong.TryParse(text3, out var result3))
											{
												return null;
											}
											reset = new DateTime?(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))?.AddSeconds(result3).ToLocalTime();
										}
										if (!reset.HasValue)
										{
											return null;
										}
										return new RateLimitInfo(remaining, reset, total);
									}
									return null;
								}
								return null;
							}
							return null;
						}
						return null;
					}
					return null;
				}
				return null;
			}
			return null;
		}
	}
}
