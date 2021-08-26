using System;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BeatSaverSharp.Interfaces;
using BeatSaverSharp.Net;

namespace BeatSaverSharp
{
	
	
	public sealed class BeatSaver : IDisposable
	{
		public static readonly string BaseURL = "https://beatsaver.com";

		internal bool Disposed
		{
			get;
			private set;
		}

		internal Http HttpInstance
		{
			get;
		}

		internal HttpClient HttpClient
		{
			get
			{
				if (!HttpInstance.Disposed)
				{
					return HttpInstance.Client;
				}
				throw new ObjectDisposedException("HttpClient");
			}
		}

		
		public BeatSaver(HttpOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			HttpInstance = new Http(options);
		}

		
		public BeatSaver(string name, Version version)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if ((object)version == null)
			{
				throw new ArgumentNullException("version");
			}
			HttpOptions options = new HttpOptions(name, version);
			HttpInstance = new Http(options);
		}

		
		public BeatSaver(string name, string version)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (version == null)
			{
				throw new ArgumentNullException("version");
			}
			HttpOptions options = new HttpOptions(name, version);
			HttpInstance = new Http(options);
		}

		public void Dispose()
		{
			if (!Disposed)
			{
				Disposed = true;
				HttpInstance.Dispose();
			}
		}

		internal async Task<Beatmap> FetchSingle(string url, StandardRequestOptions options)
		{
			if (Disposed)
			{
				throw new ObjectDisposedException("BeatSaver");
			}
			HttpRequest request = HttpRequest.FromOptions(url, options);
			HttpResponse httpResponse = await HttpInstance.GetAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			if (httpResponse.StatusCode == HttpStatusCode.NotFound)
			{
				return null;
			}
			Beatmap beatmap = httpResponse.JSON<Beatmap>();
			if ((object)beatmap == null)
			{
				return null;
			}
			beatmap.Client = this;
			beatmap.Uploader.Client = this;
			return beatmap;
		}

		internal async Task<Beatmap> StatsFromHash(string hash, StandardRequestOptions options)
		{
			return await FetchSingle("/stats/hash/" + hash, options).ConfigureAwait(continueOnCapturedContext: false);
		}

		internal async Task<Page<T>> FetchPaged<T>(string url, IPagedRequestOptions options) where T : class, IPagedRequestOptions, IRequest
		{
			if (Disposed)
			{
				throw new ObjectDisposedException("BeatSaver");
			}
			HttpRequest request = HttpRequest.FromOptions(url, options);
			HttpResponse httpResponse = await HttpInstance.GetAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			if (httpResponse.StatusCode == HttpStatusCode.NotFound)
			{
				return null;
			}
			Page<T> page = httpResponse.JSON<Page<T>>();
			if ((object)page == null)
			{
				return null;
			}
			page.Client = this;
			page.URI = url;
			page.Options = (T)options;
			foreach (Beatmap doc in page.Docs)
			{
				doc.Client = this;
				doc.Uploader.Client = this;
			}
			return page;
		}

		
		public async Task<Beatmap> Key(string key, StandardRequestOptions options = null)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			return await FetchSingle("/maps/id/" + key, options ?? StandardRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
		}

		
		public async Task<Beatmap> Hash(string hash, StandardRequestOptions options = null)
		{
			if (hash == null)
			{
				throw new ArgumentNullException("hash");
			}
			return await FetchSingle("/maps/hash/" + hash, options ?? StandardRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Page<PagedRequestOptions>> Latest( PagedRequestOptions options = null)
		{
			return await FetchPaged<PagedRequestOptions>("/maps/latest", options ?? PagedRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Page<PagedRequestOptions>> Hot( PagedRequestOptions options = null)
		{
			return await FetchPaged<PagedRequestOptions>("/maps/hot", options ?? PagedRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Page<PagedRequestOptions>> Rating( PagedRequestOptions options = null)
		{
			return await FetchPaged<PagedRequestOptions>("/maps/rating", options ?? PagedRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Page<PagedRequestOptions>> Downloads( PagedRequestOptions options = null)
		{
			return await FetchPaged<PagedRequestOptions>("/maps/downloads", options ?? PagedRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Page<SearchRequestOptions>> Search( SearchRequestOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			return await FetchPaged<SearchRequestOptions>("/search/text", options).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Page<SearchRequestOptions>> SearchAdvanced( SearchRequestOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			return await FetchPaged<SearchRequestOptions>("/search/advanced", options).ConfigureAwait(continueOnCapturedContext: false);
		}

		
		public async Task<User> User(string id, StandardRequestOptions options = null)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			HttpRequest request = HttpRequest.FromOptions("/users/find/" + id, options ?? StandardRequestOptions.Default);
			HttpResponse httpResponse = await HttpInstance.GetAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			if (httpResponse.StatusCode == HttpStatusCode.NotFound)
			{
				return null;
			}
			User user = httpResponse.JSON<User>();
			if ((object)user == null)
			{
				return null;
			}
			user.Client = this;
			return user;
		}
	}
}
