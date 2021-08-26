using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace BeatSaverSharp{
	public sealed class BeatmapCharacteristic : IEquatable<BeatmapCharacteristic>
	{
		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(BeatmapCharacteristic);
			}
		}

		[JsonProperty("name")]
		public string Name
		{
			get;
			private set;
		}


		[JsonProperty("difficulties")]

		public ReadOnlyDictionary<string, BeatmapCharacteristicDifficulty> Difficulties
		{

			get;

			private set;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("BeatmapCharacteristic");
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
			builder.Append("Name");
			builder.Append(" = ");
			builder.Append((object)Name);
			builder.Append(", ");
			builder.Append("Difficulties");
			builder.Append(" = ");
			builder.Append(Difficulties);
			return true;
		}

		public static bool operator !=(BeatmapCharacteristic r1, BeatmapCharacteristic r2)
		{
			return !(r1 == r2);
		}

		public static bool operator ==(BeatmapCharacteristic r1, BeatmapCharacteristic r2)
		{
			if ((object)r1 != r2)
			{
				return r1?.Equals(r2) ?? false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return (EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name)) * -1521134295 + EqualityComparer<ReadOnlyDictionary<string, BeatmapCharacteristicDifficulty>>.Default.GetHashCode(Difficulties);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as BeatmapCharacteristic);
		}

		public bool Equals(BeatmapCharacteristic other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<string>.Default.Equals(Name, other.Name))
			{
				return EqualityComparer<ReadOnlyDictionary<string, BeatmapCharacteristicDifficulty>>.Default.Equals(Difficulties, other.Difficulties);
			}
			return false;
		}

		public BeatmapCharacteristic _003CClone_003E_0024()
		{
			return new BeatmapCharacteristic(this);
		}

		private BeatmapCharacteristic(BeatmapCharacteristic original)
		{
			Name = original.Name;
			Difficulties = original.Difficulties;
		}

		public BeatmapCharacteristic()
		{
		}
	}
}
