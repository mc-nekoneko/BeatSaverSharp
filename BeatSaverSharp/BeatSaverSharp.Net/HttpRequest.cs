using System;
using System.Runtime.CompilerServices;
using System.Threading;
using BeatSaverSharp.Interfaces;

namespace BeatSaverSharp.Net
{
	
	
	internal struct HttpRequest : IRequest
	{
		private readonly string _uri;

		public string Uri
		{
			get
			{
				string text = Query.ToQueryString();
				if (text == null)
				{
					return _uri;
				}
				return _uri + text;
			}
		}

		public QueryStore Query
		{
			
			get;
		}

		public MultiKeyDictionary<string, string> Headers
		{
			
			get;
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

		public static HttpRequest FromOptions(string url, IRequestOptions options)
		{
			return options.CreateRequest(url);
		}

		
		public HttpRequest(string uri)
		{
			_uri = uri?.TrimStart(new char[1]
			{
				'/'
			}) ?? throw new ArgumentNullException("uri");
			Query = new QueryStore();
			Headers = new MultiKeyDictionary<string, string>();
			Token = null;
			Progress = null;
		}
	}
}
