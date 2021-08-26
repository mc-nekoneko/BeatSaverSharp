using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	
	
	public sealed class User : IEquatable<User>
	{
		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(User);
			}
		}

		[JsonProperty("_id")]
		public string ID
		{
			get;
			private set;
		}

		[JsonProperty("username")]
		public string Username
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

		public async Task<Page<PagedRequestOptions>> Beatmaps( PagedRequestOptions options = null)
		{
			if (Client == null)
			{
				throw new NullReferenceException("Client should not be null!");
			}
			return await Client.FetchPaged<PagedRequestOptions>("/maps/uploader/" + ID, options ?? PagedRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
		}

		public bool Equals(User u)
		{
			if ((object)u == null)
			{
				return false;
			}
			if ((object)this == u)
			{
				return true;
			}
			if (GetType() != u.GetType())
			{
				return false;
			}
			return ID == u.ID;
		}

		public override int GetHashCode()
		{
			if (ID != null)
			{
				return ID.GetHashCode();
			}
			throw new NullReferenceException("ID should not be null!");
		}

		
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("User");
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
			builder.Append("ID");
			builder.Append(" = ");
			builder.Append((object)ID);
			builder.Append(", ");
			builder.Append("Username");
			builder.Append(" = ");
			builder.Append((object)Username);
			return true;
		}

		
		public static bool operator !=(User r1, User r2)
		{
			return !(r1 == r2);
		}

		
		public static bool operator ==(User r1, User r2)
		{
			if ((object)r1 != r2)
			{
				return r1?.Equals(r2) ?? false;
			}
			return true;
		}

		
		public override bool Equals(object obj)
		{
			return Equals(obj as User);
		}

		public User _003CClone_003E_0024()
		{
			return new User(this);
		}

		private User(User original)
		{
			ID = original.ID;
			Username = original.Username;
			Client = original.Client;
		}

		public User()
		{
		}
	}
}
