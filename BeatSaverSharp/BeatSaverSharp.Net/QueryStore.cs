using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BeatSaverSharp.Net
{
	
	
	internal sealed class QueryStore : MultiKeyDictionary<string, string>
	{
		public string ToQueryString()
		{
			if (base.Count == 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, IEnumerable<string>> current = enumerator.Current;
					foreach (string item in current.Value)
					{
						if (item != null)
						{
							stringBuilder.Append((stringBuilder.Length == 0) ? '?' : '&');
							stringBuilder.Append(current.Key);
							if (!string.IsNullOrEmpty(item))
							{
								stringBuilder.Append('=');
								stringBuilder.Append(item);
							}
						}
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
}
