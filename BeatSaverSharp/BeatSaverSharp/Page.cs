using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BeatSaverSharp.Interfaces;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	public sealed class Page<T> : IEquatable<Page<T>> where T : class, IPagedRequestOptions, IRequest
	{
		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(Page<T>);
			}
		}

		[JsonProperty("docs")]
		public ReadOnlyCollection<Beatmap> Docs
		{
			get;
			private set;
		}

		[JsonProperty("totalDocs")]
		public int TotalDocs
		{
			get;
			private set;
		}

		[JsonProperty("lastPage")]
		public uint LastPage
		{
			get;
			private set;
		}

		[JsonProperty("prevPage")]
		public uint? PreviousPage
		{
			get;
			private set;
		}

		[JsonProperty("nextPage")]
		public uint? NextPage
		{
			get;
			private set;
		}

		[JsonIgnore]
		internal BeatSaver Client
		{
			get;
			set;
		}

		[JsonIgnore]
		internal string URI
		{
			get;
			set;
		}

		[JsonIgnore]
		internal T Options
		{
			get;
			set;
		}

		public async Task<Page<T>> Previous(T options = null)
		{
			if (!PreviousPage.HasValue)
			{
				throw new NullReferenceException("PreviousPage is null!");
			}
			if (Client == null)
			{
				throw new NullReferenceException("Client should not be null!");
			}
			if (URI == null)
			{
				throw new NullReferenceException("URI should not be null!");
			}
			if (Options == null)
			{
				throw new NullReferenceException("Options should not be null!");
			}
			IPagedRequestOptions options2 = Options.Clone(options, PreviousPage.Value);
			return await Client.FetchPaged<T>(URI, options2).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<Page<T>> Next( T options = null)
		{
			if (!NextPage.HasValue)
			{
				throw new NullReferenceException("NextPage is null!");
			}
			if (Client == null)
			{
				throw new NullReferenceException("Client should not be null!");
			}
			if (URI == null)
			{
				throw new NullReferenceException("URI should not be null!");
			}
			if (Options == null)
			{
				throw new NullReferenceException("Options should not be null!");
			}
			IPagedRequestOptions options2 = Options.Clone(options, NextPage.Value);
			return await Client.FetchPaged<T>(URI, options2).ConfigureAwait(continueOnCapturedContext: false);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Page");
			stringBuilder.Append(" { ");
			if (PrintMembers(stringBuilder))
			{
				stringBuilder.Append(" ");
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		private bool PrintMembers(StringBuilder builder)
		{
			builder.Append("Docs");
			builder.Append(" = ");
			builder.Append(Docs);
			builder.Append(", ");
			builder.Append("TotalDocs");
			builder.Append(" = ");
			builder.Append(TotalDocs.ToString());
			builder.Append(", ");
			builder.Append("LastPage");
			builder.Append(" = ");
			builder.Append(LastPage.ToString());
			builder.Append(", ");
			builder.Append("PreviousPage");
			builder.Append(" = ");
			builder.Append(PreviousPage.ToString());
			builder.Append(", ");
			builder.Append("NextPage");
			builder.Append(" = ");
			builder.Append(NextPage.ToString());
			return true;
		}


		public override int GetHashCode()
		{
			return (((((((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<ReadOnlyCollection<Beatmap>>.Default.GetHashCode(Docs)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(TotalDocs)) * -1521134295 + EqualityComparer<uint>.Default.GetHashCode(LastPage)) * -1521134295 + EqualityComparer<uint?>.Default.GetHashCode(PreviousPage)) * -1521134295 + EqualityComparer<uint?>.Default.GetHashCode(NextPage)) * -1521134295 + EqualityComparer<BeatSaver>.Default.GetHashCode(Client)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(URI)) * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Options);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as Page<T>);
		}

		public bool Equals(Page<T> other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<ReadOnlyCollection<Beatmap>>.Default.Equals(Docs, other.Docs) && EqualityComparer<int>.Default.Equals(TotalDocs, other.TotalDocs) && EqualityComparer<uint>.Default.Equals(LastPage, other.LastPage) && EqualityComparer<uint?>.Default.Equals(PreviousPage, other.PreviousPage) && EqualityComparer<uint?>.Default.Equals(NextPage, other.NextPage) && EqualityComparer<BeatSaver>.Default.Equals(Client, other.Client) && EqualityComparer<string>.Default.Equals(URI, other.URI))
			{
				return EqualityComparer<T>.Default.Equals(Options, other.Options);
			}
			return false;
		}


		public Page<T> _003CClone_003E_0024()
		{
			return new Page<T>(this);
		}

		private Page( Page<T> original)
		{
			Docs = original.Docs;
			TotalDocs = original.TotalDocs;
			LastPage = original.LastPage;
			PreviousPage = original.PreviousPage;
			NextPage = original.NextPage;
			Client = original.Client;
			URI = original.URI;
			Options = original.Options;
		}

		public Page()
		{
		}
	}
}
