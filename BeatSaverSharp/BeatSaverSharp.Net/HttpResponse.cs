using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace BeatSaverSharp.Net
{
	
	
	internal sealed class HttpResponse
	{
		private readonly byte[] _body;

		public HttpStatusCode StatusCode
		{
			get;
		}

		public string ReasonPhrase
		{
			get;
		}

		public HttpResponseHeaders Headers
		{
			get;
		}

		public HttpRequestMessage RequestMessage
		{
			get;
		}

		public bool IsSuccessStatusCode
		{
			get;
		}

		public RateLimitInfo? RateLimit
		{
			get;
		}

		public byte[] Bytes => _body;

		public string Body => Encoding.UTF8.GetString(_body);

		internal HttpResponse(HttpResponseMessage resp, byte[] body)
		{
			StatusCode = resp.StatusCode;
			ReasonPhrase = resp.ReasonPhrase;
			Headers = resp.Headers;
			RequestMessage = resp.RequestMessage;
			IsSuccessStatusCode = resp.IsSuccessStatusCode;
			RateLimit = RateLimitInfo.FromHttp(resp);
			_body = body;
		}

		
		public T JSON<T>()
		{
			using (StringReader reader = new StringReader(Body))
			{
				using (JsonTextReader reader2 = new JsonTextReader(reader))
				{
					return Http.Serializer.Deserialize<T>(reader2);
				}
			}
		}
	}
}
