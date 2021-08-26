using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BeatSaverSharp.Interfaces
{
	
	public interface IRequest
	{
		CancellationToken? Token
		{
			get;
		}

		IProgress<double> Progress
		{
			get;
		}
	}
}
