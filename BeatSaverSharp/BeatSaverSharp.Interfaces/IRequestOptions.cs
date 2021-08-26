using System.Runtime.CompilerServices;
using BeatSaverSharp.Net;

namespace BeatSaverSharp.Interfaces
{
	public interface IRequestOptions
	{
		internal HttpRequest CreateRequest(string url);
	}
}
