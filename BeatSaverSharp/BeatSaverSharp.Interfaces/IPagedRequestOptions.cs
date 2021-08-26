using System.Runtime.CompilerServices;

namespace BeatSaverSharp.Interfaces
{
	public interface IPagedRequestOptions : IRequestOptions
	{
		uint Page
		{
			get;
		}

		internal IPagedRequestOptions Clone( IRequest options = null, uint? page = null);
	}
}
