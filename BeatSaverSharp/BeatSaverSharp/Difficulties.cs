using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	
	
	public sealed class Difficulties : IEquatable<Difficulties>
	{
		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(Difficulties);
			}
		}

		[JsonProperty("easy")]
		public bool Easy
		{
			get;
			private set;
		}

		[JsonProperty("normal")]
		public bool Normal
		{
			get;
			private set;
		}

		[JsonProperty("hard")]
		public bool Hard
		{
			get;
			private set;
		}

		[JsonProperty("expert")]
		public bool Expert
		{
			get;
			private set;
		}

		[JsonProperty("expertPlus")]
		public bool ExpertPlus
		{
			get;
			private set;
		}

		
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Difficulties");
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
			builder.Append("Easy");
			builder.Append(" = ");
			builder.Append(Easy.ToString());
			builder.Append(", ");
			builder.Append("Normal");
			builder.Append(" = ");
			builder.Append(Normal.ToString());
			builder.Append(", ");
			builder.Append("Hard");
			builder.Append(" = ");
			builder.Append(Hard.ToString());
			builder.Append(", ");
			builder.Append("Expert");
			builder.Append(" = ");
			builder.Append(Expert.ToString());
			builder.Append(", ");
			builder.Append("ExpertPlus");
			builder.Append(" = ");
			builder.Append(ExpertPlus.ToString());
			return true;
		}

		
		public static bool operator !=(Difficulties r1, Difficulties r2)
		{
			return !(r1 == r2);
		}

		
		public static bool operator ==(Difficulties r1, Difficulties r2)
		{
			if ((object)r1 != r2)
			{
				return r1?.Equals(r2) ?? false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ((((EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(Easy)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(Normal)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(Hard)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(Expert)) * -1521134295 + EqualityComparer<bool>.Default.GetHashCode(ExpertPlus);
		}

		
		public override bool Equals(object obj)
		{
			return Equals(obj as Difficulties);
		}

		
		public bool Equals(Difficulties other)
		{
			if ((object)other != null && EqualityContract == other.EqualityContract && EqualityComparer<bool>.Default.Equals(Easy, other.Easy) && EqualityComparer<bool>.Default.Equals(Normal, other.Normal) && EqualityComparer<bool>.Default.Equals(Hard, other.Hard) && EqualityComparer<bool>.Default.Equals(Expert, other.Expert))
			{
				return EqualityComparer<bool>.Default.Equals(ExpertPlus, other.ExpertPlus);
			}
			return false;
		}

		public Difficulties _003CClone_003E_0024()
		{
			return new Difficulties(this);
		}

		private Difficulties(Difficulties original)
		{
			Easy = original.Easy;
			Normal = original.Normal;
			Hard = original.Hard;
			Expert = original.Expert;
			ExpertPlus = original.ExpertPlus;
		}

		public Difficulties()
		{
		}
	}
}
