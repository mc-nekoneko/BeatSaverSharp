using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BeatSaverSharp.Net
{

	internal class MultiKeyDictionary<TKey,  TValue> : Dictionary<TKey, IEnumerable<TValue>>
	{
		public void Append(TKey key, TValue value)
		{
			Append(key, new List<TValue>
			{
				value
			});
		}

		public void Append(TKey key, IEnumerable<TValue> value)
		{
			List<TValue> list = (ContainsKey(key) ? new List<TValue>(base[key]) : new List<TValue>());
			list.AddRange(value);
			base[key] = list;
		}
	}
}
