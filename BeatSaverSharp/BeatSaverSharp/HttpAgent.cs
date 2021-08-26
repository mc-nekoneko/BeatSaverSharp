using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace BeatSaverSharp
{
	
	
	public struct HttpAgent
	{
		internal static readonly HttpAgent Self = new HttpAgent("BeatSaverSharp", Assembly.GetExecutingAssembly().GetName().Version.ToString(3), "https://github.com/lolPants/BeatSaverSharp");

		public string Name
		{
			
			get;
		}

		public string Version
		{
			
			get;
		}

		
		
		public string Link
		{
			
			
			get;
		}

		public string UserAgent
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(Name).Append('/').Append(Version);
				if (Link != null)
				{
					stringBuilder.Append(" (+").Append(Link).Append(')');
				}
				return stringBuilder.ToString();
			}
		}

		
		public HttpAgent(string name, string version, string link = null)
		{
			Name = name ?? throw new ArgumentNullException("name");
			Version = version ?? throw new ArgumentNullException("version");
			Link = link;
		}

		
		public HttpAgent(string name, Version version, string link = null)
		{
			Name = name ?? throw new ArgumentNullException("name");
			Version = version?.ToString() ?? throw new ArgumentNullException("version");
			Link = link;
		}

		public override string ToString()
		{
			return UserAgent;
		}
	}
}
