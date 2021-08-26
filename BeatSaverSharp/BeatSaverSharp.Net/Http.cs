using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using BeatSaverSharp.Exceptions;
using Newtonsoft.Json;

namespace BeatSaverSharp.Net
{
	
	
	internal sealed class Http : IDisposable
	{
		internal static readonly JsonSerializer Serializer = new JsonSerializer();

		private static readonly ConcurrentDictionary<string, string> _etagCache = new ConcurrentDictionary<string, string>();

		private static readonly ConcurrentDictionary<string, HttpResponse> _responseCache = new ConcurrentDictionary<string, HttpResponse>();

		internal bool Disposed
		{
			get;
			private set;
		}

		internal HttpOptions Options
		{
			get;
		}

		internal HttpClient Client
		{
			get;
		}

		internal Http(HttpOptions options)
		{
			Options = options;
			HttpClientHandler handler = new HttpClientHandler
			{
				AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate)
			};
			Client = new HttpClient(handler)
			{
				BaseAddress = new Uri(Options.BaseURL + "/api/"),
				Timeout = Options.Timeout
			};
			Client.DefaultRequestHeaders.Add("User-Agent", options.UserAgent);
		}

		internal async Task<HttpResponse> GetAsync(HttpRequest request)
		{
			if (Disposed)
			{
				throw new ObjectDisposedException("Http");
			}
			CancellationToken token = request.Token ?? CancellationToken.None;
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, request.Uri)
			{
				Version = Options.HttpVersion
			};
			foreach (KeyValuePair<string, IEnumerable<string>> header in request.Headers)
			{
				if (!(header.Key.ToLower() == "User-Agent".ToLower()) && !(header.Key.ToLower() == "If-None-Match".ToLower()))
				{
					httpRequestMessage.Headers.Add(header.Key, header.Value);
				}
			}
			string etagMatch = null;
			if (!Options.DisableCaching && _etagCache.TryGetValue(request.Uri, out etagMatch) && _responseCache.ContainsKey(etagMatch))
			{
				httpRequestMessage.Headers.Add("If-None-Match", etagMatch);
			}
			HttpResponseMessage resp = await Client.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead, token).ConfigureAwait(continueOnCapturedContext: false);

			if (token.IsCancellationRequested)
			{
				throw new TaskCanceledException();
			}
			if (!Options.DisableCaching && etagMatch != null && resp.StatusCode == HttpStatusCode.NotModified && _responseCache.TryGetValue(etagMatch, out var value))
			{
				request.Progress?.Report(1.0);
				return value;
			}
			using (MemoryStream ms = new MemoryStream())
			{
				using (Stream s = await resp.Content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false))
				{
					int num2 = 8192;
					byte[] buffer = new byte[num2];
					long? contentLength = resp.Content.Headers.ContentLength;
					long totalRead = 0L;
					request.Progress?.Report(0.0);
					while (true)
					{
						int num3;
						int bytesRead = (num3 = await s.ReadAsync(buffer, 0, buffer.Length, token).ConfigureAwait(continueOnCapturedContext: false));
						if (num3 <= 0)
						{
							break;
						}
						if (token.IsCancellationRequested)
						{
							throw new TaskCanceledException();
						}
						if (contentLength.HasValue)
						{
							double value2 = (double)totalRead / (double)contentLength.Value;
							request.Progress?.Report(value2);
						}
						await ms.WriteAsync(buffer, 0, bytesRead, token).ConfigureAwait(continueOnCapturedContext: false);
						totalRead += bytesRead;
					}
					request.Progress?.Report(1.0);
					byte[] body = ms.ToArray();
					HttpResponse httpResponse = new HttpResponse(resp, body);
					if (!Options.DisableCaching && resp.Headers.TryGetValues("ETag", out var values))
					{
						string text = values.FirstOrDefault();
						if (text != null)
						{
							if (_etagCache.TryGetValue(request.Uri, out var value3) && value3 != text)
							{
								_responseCache.TryRemove(value3, out var _);
							}
							_etagCache[request.Uri] = text;
							_responseCache[text] = httpResponse;
						}
					}
					return httpResponse;
				}
			}
		}

		public void Dispose()
		{
			if (!Disposed)
			{
				Disposed = true;
				Client.Dispose();
			}
		}
	}
}
