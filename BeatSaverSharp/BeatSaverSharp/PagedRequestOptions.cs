using System;
using System.Runtime.CompilerServices;
using System.Threading;
using BeatSaverSharp.Interfaces;
using BeatSaverSharp.Net;

namespace BeatSaverSharp
{
	public sealed class PagedRequestOptions : IPagedRequestOptions, IRequestOptions, IRequest
	{
		public enum AutomapFilter
		{
			Include = 1,
			Exclude = 0,
			Only = -1
		}

		public static PagedRequestOptions Default
		{
			
			get
			{
				return new PagedRequestOptions();
			}
		}

		public uint Page
		{
			get;
			set;
		}

		public AutomapFilter Automaps
		{
			get;
			set;
		} = AutomapFilter.Include;


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
			HttpRequest httpRequest = new HttpRequest($"{url}/{Page}");
			httpRequest.Token = Token;
			httpRequest.Progress = Progress;
			HttpRequest result = httpRequest;
			if (Automaps == AutomapFilter.Include || Automaps == AutomapFilter.Only)
			{
				int automaps = (int)Automaps;
				result.Query.Append("automapper", automaps.ToString());
			}
			return result;
		}

		
		IPagedRequestOptions IPagedRequestOptions.Clone( IRequest options, uint? page)
		{
			PagedRequestOptions pagedRequestOptions = new PagedRequestOptions
			{
				Token = options?.Token,
				Progress = options?.Progress,
				Automaps = Automaps
			};
			if (page.HasValue)
			{
				pagedRequestOptions.Page = page.Value;
			}
			return pagedRequestOptions;
		}
	}
}
