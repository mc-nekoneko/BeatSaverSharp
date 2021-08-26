using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace BeatSaverSharp
{
	
	
	public sealed class HttpOptions
	{
		private static readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(30.0);

		private static readonly bool _defaultHandleRateLimits = false;

		private static readonly Version _defaultHttpVersion = System.Net.HttpVersion.Version11;

		public TimeSpan Timeout
		{
			get;
		}

		public string BaseURL
		{
			get;
		}

		public Version HttpVersion
		{
			get;
		}

		public bool HandleRateLimits
		{
			get;
		}

		public HttpAgent[] Agents
		{
			get;
		}

		public bool DisableCaching
		{
			get;
		}

		public string UserAgent => string.Join(" ", Agents);

		
		public HttpOptions(string name, Version version, TimeSpan? timeout = null, string baseURL = null, Version httpVersion = null, bool? handleRateLimits = null, List<HttpAgent> agents = null, bool disableCaching = false)
		{
			Timeout = timeout ?? _defaultTimeout;
			BaseURL = baseURL ?? BeatSaver.BaseURL;
			HttpVersion = httpVersion ?? _defaultHttpVersion;
			HandleRateLimits = handleRateLimits ?? _defaultHandleRateLimits;
			DisableCaching = disableCaching;
			string name2 = name ?? throw new ArgumentNullException("name");
			Version version2 = version ?? throw new ArgumentNullException("version");
			Agents = ConstructAgents(new HttpAgent(name2, version2), agents);
		}

		
		public HttpOptions(string name, string version, TimeSpan? timeout = null, string baseURL = null, Version httpVersion = null, bool? handleRateLimits = null, List<HttpAgent> agents = null, bool disableCaching = false)
		{
			Timeout = timeout ?? _defaultTimeout;
			BaseURL = baseURL ?? BeatSaver.BaseURL;
			HttpVersion = httpVersion ?? _defaultHttpVersion;
			HandleRateLimits = handleRateLimits ?? _defaultHandleRateLimits;
			DisableCaching = disableCaching;
			string name2 = name ?? throw new ArgumentNullException("name");
			string version2 = version ?? throw new ArgumentNullException("version");
			Agents = ConstructAgents(new HttpAgent(name2, version2), agents);
		}

		private static HttpAgent[] ConstructAgents(HttpAgent appAgent,  List<HttpAgent> agents)
		{
			List<HttpAgent> list = new List<HttpAgent>
			{
				appAgent
			};
			if (agents != null)
			{
				foreach (HttpAgent agent in agents)
				{
					if (agent.Name == null)
					{
						throw new NullReferenceException("agent.Name must not be null!");
					}
					if (agent.Version == null)
					{
						throw new NullReferenceException("agent.Version must not be null!");
					}
					list.Add(agent);
				}
			}
			list.Add(HttpAgent.Self);
			return list.ToArray();
		}
	}
}
