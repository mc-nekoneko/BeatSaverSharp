using System;
using System.Runtime.CompilerServices;
using System.Threading;
using BeatSaverSharp.Interfaces;
using BeatSaverSharp.Net;

namespace BeatSaverSharp
{
	
	
	public sealed class SearchRequestOptions : IPagedRequestOptions, IRequestOptions, IRequest
	{
		public uint Page
		{
			get;
			set;
		}

		public string Query
		{
			get;
			set;
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

		
		public SearchRequestOptions(string query)
		{
			Query = query ?? throw new ArgumentNullException("query");
		}

		HttpRequest IRequestOptions.CreateRequest(string url)
		{
			HttpRequest httpRequest = new HttpRequest($"{url}/{Page}");
			httpRequest.Token = Token;
			httpRequest.Progress = Progress;
			HttpRequest result = httpRequest;
			if (Query == null)
			{
				throw new NullReferenceException("Query should not be null!");
			}
			result.Query.Append("q", Query);
			return result;
		}

		IPagedRequestOptions IPagedRequestOptions.Clone( IRequest options, uint? page)
		{
			SearchRequestOptions searchRequestOptions = new SearchRequestOptions(Query)
			{
				Token = options?.Token,
				Progress = options?.Progress
			};
			if (page.HasValue)
			{
				searchRequestOptions.Page = page.Value;
			}
			return searchRequestOptions;
		}
	}
}
