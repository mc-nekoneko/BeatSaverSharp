using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	
	
	public sealed class Stats : IEquatable<Stats>
	{
		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(Stats);
			}
		}

		[JsonProperty("downloads")]
		public int Downloads
		{
			get;
			private set;
		}

		[JsonProperty("plays")]
		public int Plays
		{
			get;
			private set;
		}

		[JsonProperty("upVotes")]
		public int UpVotes
		{
			get;
			private set;
		}

		[JsonProperty("downVotes")]
		public int DownVotes
		{
			get;
			private set;
		}

		[JsonProperty("rating")]
		public float Rating
		{
			get;
			private set;
		}

		[JsonProperty("heat")]
		public float Heat
		{
			get;
			private set;
		}

		
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Stats");
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
			builder.Append("Downloads");
			builder.Append(" = ");
			builder.Append(Downloads.ToString());
			builder.Append(", ");
			builder.Append("Plays");
			builder.Append(" = ");
			builder.Append(Plays.ToString());
			builder.Append(", ");
			builder.Append("UpVotes");
			builder.Append(" = ");
			builder.Append(UpVotes.ToString());
			builder.Append(", ");
			builder.Append("DownVotes");
			builder.Append(" = ");
			builder.Append(DownVotes.ToString());
			builder.Append(", ");
			builder.Append("Rating");
			builder.Append(" = ");
			builder.Append(Rating.ToString());
			builder.Append(", ");
			builder.Append("Heat");
			builder.Append(" = ");
			builder.Append(Heat.ToString());
			return true;
		}

		
		public static bool operator !=(Stats r1, Stats r2)
		{
			return !(r1 == r2);
		}

		
		public static bool operator ==(Stats r1, Stats r2)
		{
			if ((object)r1 != r2)
			{
				return r1?.Equals(r2) ?? false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return (((((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Downloads)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Plays)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(UpVotes)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(DownVotes)) * -1521134295 + EqualityComparer<float>.Default.GetHashCode(Rating)) * -1521134295 + EqualityComparer<float>.Default.GetHashCode(Heat);
		}

		
		public override bool Equals(object obj)
		{
			return Equals(obj as Stats);
		}

		
		public bool Equals(Stats other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<int>.Default.Equals(Downloads, other.Downloads) && EqualityComparer<int>.Default.Equals(Plays, other.Plays) && EqualityComparer<int>.Default.Equals(UpVotes, other.UpVotes) && EqualityComparer<int>.Default.Equals(DownVotes, other.DownVotes) && EqualityComparer<float>.Default.Equals(Rating, other.Rating))
			{
				return EqualityComparer<float>.Default.Equals(Heat, other.Heat);
			}
			return false;
		}

		public Stats _003CClone_003E_0024()
		{
			return new Stats(this);
		}

		private Stats(Stats original)
		{
			Downloads = original.Downloads;
			Plays = original.Plays;
			UpVotes = original.UpVotes;
			DownVotes = original.DownVotes;
			Rating = original.Rating;
			Heat = original.Heat;
		}

		public Stats()
		{
		}
	}
}
