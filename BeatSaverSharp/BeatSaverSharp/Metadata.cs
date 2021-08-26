using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	
	
	public sealed class Metadata : IEquatable<Metadata>
	{
		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(Metadata);
			}
		}

		[JsonProperty("songName")]
		public string SongName
		{
			get;
			private set;
		}

		[JsonProperty("songSubName")]
		public string SongSubName
		{
			get;
			private set;
		}

		[JsonProperty("songAuthorName")]
		public string SongAuthorName
		{
			get;
			private set;
		}

		[JsonProperty("levelAuthorName")]
		public string LevelAuthorName
		{
			get;
			private set;
		}

		[JsonProperty("duration")]
		public long Duration
		{
			get;
			private set;
		}

		[JsonProperty("bpm")]
		public float BPM
		{
			get;
			private set;
		}

		
		[JsonProperty("automapper")]
		
		public string Automapper
		{
			
			get;
			
			private set;
		}

		[JsonProperty("difficulties")]
		public Difficulties Difficulties
		{
			get;
			private set;
		}

		[JsonProperty("characteristics")]
		public ReadOnlyCollection<BeatmapCharacteristic> Characteristics
		{
			get;
			private set;
		}

		
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Metadata");
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
			builder.Append("SongName");
			builder.Append(" = ");
			builder.Append((object)SongName);
			builder.Append(", ");
			builder.Append("SongSubName");
			builder.Append(" = ");
			builder.Append((object)SongSubName);
			builder.Append(", ");
			builder.Append("SongAuthorName");
			builder.Append(" = ");
			builder.Append((object)SongAuthorName);
			builder.Append(", ");
			builder.Append("LevelAuthorName");
			builder.Append(" = ");
			builder.Append((object)LevelAuthorName);
			builder.Append(", ");
			builder.Append("Duration");
			builder.Append(" = ");
			builder.Append(Duration.ToString());
			builder.Append(", ");
			builder.Append("BPM");
			builder.Append(" = ");
			builder.Append(BPM.ToString());
			builder.Append(", ");
			builder.Append("Automapper");
			builder.Append(" = ");
			builder.Append((object)Automapper);
			builder.Append(", ");
			builder.Append("Difficulties");
			builder.Append(" = ");
			builder.Append(Difficulties);
			builder.Append(", ");
			builder.Append("Characteristics");
			builder.Append(" = ");
			builder.Append(Characteristics);
			return true;
		}

		
		public static bool operator !=(Metadata r1, Metadata r2)
		{
			return !(r1 == r2);
		}

		
		public static bool operator ==(Metadata r1, Metadata r2)
		{
			if ((object)r1 != r2)
			{
				return r1?.Equals(r2) ?? false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ((((((((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SongName)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SongSubName)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SongAuthorName)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LevelAuthorName)) * -1521134295 + EqualityComparer<long>.Default.GetHashCode(Duration)) * -1521134295 + EqualityComparer<float>.Default.GetHashCode(BPM)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Automapper)) * -1521134295 + EqualityComparer<Difficulties>.Default.GetHashCode(Difficulties)) * -1521134295 + EqualityComparer<ReadOnlyCollection<BeatmapCharacteristic>>.Default.GetHashCode(Characteristics);
		}

		
		public override bool Equals(object obj)
		{
			return Equals(obj as Metadata);
		}

		
		public bool Equals(Metadata other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(SongName, other.SongName) && EqualityComparer<string>.Default.Equals(SongSubName, other.SongSubName) && EqualityComparer<string>.Default.Equals(SongAuthorName, other.SongAuthorName) && EqualityComparer<string>.Default.Equals(LevelAuthorName, other.LevelAuthorName) && EqualityComparer<long>.Default.Equals(Duration, other.Duration) && EqualityComparer<float>.Default.Equals(BPM, other.BPM) && EqualityComparer<string>.Default.Equals(Automapper, other.Automapper) && EqualityComparer<Difficulties>.Default.Equals(Difficulties, other.Difficulties))
			{
				return EqualityComparer<ReadOnlyCollection<BeatmapCharacteristic>>.Default.Equals(Characteristics, other.Characteristics);
			}
			return false;
		}

		public Metadata _003CClone_003E_0024()
		{
			return new Metadata(this);
		}

		private Metadata(Metadata original)
		{
			SongName = original.SongName;
			SongSubName = original.SongSubName;
			SongAuthorName = original.SongAuthorName;
			LevelAuthorName = original.LevelAuthorName;
			Duration = original.Duration;
			BPM = original.BPM;
			Automapper = original.Automapper;
			Difficulties = original.Difficulties;
			Characteristics = original.Characteristics;
		}

		public Metadata()
		{
		}
	}
}
