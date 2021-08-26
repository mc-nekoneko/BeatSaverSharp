using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	
	
	public struct RestError
	{
		[JsonProperty("code")]
		public int Code
		{
			
			get;
			private set;
		}

		[JsonProperty("identifier")]
		public string Identifier
		{
			
			get;
			private set;
		}
	}
}
