using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	
	
	public sealed class BeatmapCharacteristicDifficulty : IEquatable<BeatmapCharacteristicDifficulty>
	{
		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(BeatmapCharacteristicDifficulty);
			}
		}

		[JsonProperty("duration")]
		public float Duration
		{
			get;
			private set;
		}

		[JsonProperty("length")]
		public long Length
		{
			get;
			private set;
		}

		[JsonProperty("bombs")]
		public int Bombs
		{
			get;
			private set;
		}

		[JsonProperty("notes")]
		public int Notes
		{
			get;
			private set;
		}

		[JsonProperty("obstacles")]
		public int Obstacles
		{
			get;
			private set;
		}

		[JsonProperty("njs")]
		public float NoteJumpSpeed
		{
			get;
			private set;
		}

		[JsonProperty("njsOffset")]
		public float NoteJumpSpeedOffset
		{
			get;
			private set;
		}

		
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("BeatmapCharacteristicDifficulty");
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
			builder.Append("Duration");
			builder.Append(" = ");
			builder.Append(Duration.ToString());
			builder.Append(", ");
			builder.Append("Length");
			builder.Append(" = ");
			builder.Append(Length.ToString());
			builder.Append(", ");
			builder.Append("Bombs");
			builder.Append(" = ");
			builder.Append(Bombs.ToString());
			builder.Append(", ");
			builder.Append("Notes");
			builder.Append(" = ");
			builder.Append(Notes.ToString());
			builder.Append(", ");
			builder.Append("Obstacles");
			builder.Append(" = ");
			builder.Append(Obstacles.ToString());
			builder.Append(", ");
			builder.Append("NoteJumpSpeed");
			builder.Append(" = ");
			builder.Append(NoteJumpSpeed.ToString());
			builder.Append(", ");
			builder.Append("NoteJumpSpeedOffset");
			builder.Append(" = ");
			builder.Append(NoteJumpSpeedOffset.ToString());
			return true;
		}

		
		public static bool operator !=(BeatmapCharacteristicDifficulty r1, BeatmapCharacteristicDifficulty r2)
		{
			return !(r1 == r2);
		}

		
		public static bool operator ==(BeatmapCharacteristicDifficulty r1, BeatmapCharacteristicDifficulty r2)
		{
			if ((object)r1 != r2)
			{
				return r1?.Equals(r2) ?? false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ((((((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<float>.Default.GetHashCode(Duration)) * -1521134295 + EqualityComparer<long>.Default.GetHashCode(Length)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Bombs)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Notes)) * -1521134295 + EqualityComparer<int>.Default.GetHashCode(Obstacles)) * -1521134295 + EqualityComparer<float>.Default.GetHashCode(NoteJumpSpeed)) * -1521134295 + EqualityComparer<float>.Default.GetHashCode(NoteJumpSpeedOffset);
		}

		
		public override bool Equals(object obj)
		{
			return Equals(obj as BeatmapCharacteristicDifficulty);
		}

		
		public bool Equals(BeatmapCharacteristicDifficulty other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<float>.Default.Equals(Duration, other.Duration) && EqualityComparer<long>.Default.Equals(Length, other.Length) && EqualityComparer<int>.Default.Equals(Bombs, other.Bombs) && EqualityComparer<int>.Default.Equals(Notes, other.Notes) && EqualityComparer<int>.Default.Equals(Obstacles, other.Obstacles) && EqualityComparer<float>.Default.Equals(NoteJumpSpeed, other.NoteJumpSpeed))
			{
				return EqualityComparer<float>.Default.Equals(NoteJumpSpeedOffset, other.NoteJumpSpeedOffset);
			}
			return false;
		}

		public BeatmapCharacteristicDifficulty _003CClone_003E_0024()
		{
			return new BeatmapCharacteristicDifficulty(this);
		}

		private BeatmapCharacteristicDifficulty(BeatmapCharacteristicDifficulty original)
		{
			Duration = original.Duration;
			Length = original.Length;
			Bombs = original.Bombs;
			Notes = original.Notes;
			Obstacles = original.Obstacles;
			NoteJumpSpeed = original.NoteJumpSpeed;
			NoteJumpSpeedOffset = original.NoteJumpSpeedOffset;
		}

		public BeatmapCharacteristicDifficulty()
		{
		}
	}
}
