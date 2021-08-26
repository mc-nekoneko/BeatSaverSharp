using System;
using System.Runtime.CompilerServices;
using System.Threading;
using BeatSaverSharp.Interfaces;
using BeatSaverSharp.Net;

namespace BeatSaverSharp
{
	
	
	public sealed class StandardRequestOptions : IRequest, IRequestOptions
	{
		
		public static StandardRequestOptions Default
		{
			
			get
			{
				return new StandardRequestOptions();
			}
		}

		public CancellationToken? Token
		{
			get;
			set;
		}

		public IProgress<double> Progress
		{
			get;
			set;
		}

		
		HttpRequest IRequestOptions.CreateRequest(string url)
		{
			HttpRequest result = new HttpRequest(url);
			result.Token = Token;
			result.Progress = Progress;
			return result;
		}
	}
}
