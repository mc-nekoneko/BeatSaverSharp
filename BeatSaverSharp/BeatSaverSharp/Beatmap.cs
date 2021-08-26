using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BeatSaverSharp.Exceptions;
using BeatSaverSharp.Net;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	
	
	public sealed class Beatmap : IEquatable<Beatmap>
	{

		public class Version
        {
			[JsonProperty("key")]
			public string Key
			{
				get;
				private set;
			}
			[JsonProperty("hash")]
			public string Hash
			{
				get;
				private set;
			}
			[JsonProperty("downloadURL")]
			public string DownloadURL
			{
				get;
				private set;
			}
			[JsonProperty("coverURL")]
			public string CoverURL
			{
				get;
				private set;
			}
		}

		private Type EqualityContract
		{
			[CompilerGenerated]
			get
			{
				return typeof(Beatmap);
			}
		}

		[JsonProperty("_id")]
		public string ID
		{
			get;
			private set;
		}

		[JsonProperty("name")]
		public string Name
		{
			get;
			private set;
		}

		
		[JsonProperty("description")]
		
		public string Description
		{
			
			get;
			
			private set;
		}

		[JsonProperty("uploader")]
		public User Uploader
		{
			get;
			private set;
		}

		[JsonProperty("uploaded")]
		public DateTime Uploaded
		{
			get;
			private set;
		}

		[JsonProperty("metadata")]
		public Metadata Metadata
		{
			get;
			private set;
		}

		[JsonProperty("stats")]
		public Stats Stats
		{
			get;
			private set;
		}

		[JsonProperty("directDownload")]
		public string DirectDownload
		{
			get;
			private set;
		}

		[JsonProperty("versions")]
		public Version[] Versions;


		public Version GetLatest()
        {
			return Versions[Versions.Length - 1];
        }

		public string DownloadURL
		{
			get
			{
				return GetLatest().DownloadURL;
			}

		}

		public string Hash
		{
			get
			{
				return GetLatest().Hash;
			}
		}

		public string Key
		{
			get
			{
				return GetLatest().Key;
			}
		}

		public string CoverURL
        {
			get
			{
				return GetLatest().CoverURL;
			}
		}

		[JsonIgnore]
		
		internal BeatSaver Client
		{
			
			get;
			
			set;
		}

		[JsonIgnore]
		public string CoverFilename => Path.GetFileName(CoverURL);

		[JsonIgnore]
		public bool Partial
		{
			get
			{
				if (ID != null && Name != null)
				{
					return CoverURL == null;
				}
				return true;
			}
		}

		[JsonConstructor]
		public Beatmap()
		{
			ID = null;
			Name = null;
			Uploader = null;
			Metadata = null;
			Stats = null;
			DirectDownload = null;
			Versions = null;
		}

		
		public Beatmap(BeatSaver client, string key = null, string hash = null, string name = null)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}
			if (key == null && hash == null)
			{
				throw new ArgumentException("Key and Hash cannot both be null");
			}
			Client = client;
			ID = null;
			Name = null;
			Uploader = null;
			Metadata = null;
			Stats = null;
			DirectDownload = null;
			Versions = null;
			if (name != null)
			{
				Name = name;
			}
		}

		public async Task Populate( StandardRequestOptions options = null)
		{
			if (!Partial)
			{
				return;
			}
			if (Client == null)
			{
				throw new NullReferenceException("Client should not be null!");
			}
			if (Key == null && Hash == null)
			{
				throw new ArgumentException("Key and Hash cannot both be null");
			}
			Beatmap beatmap = ((Hash == null) ? (await Client.Key(Key, options).ConfigureAwait(continueOnCapturedContext: false)) : (await Client.Hash(Hash, options).ConfigureAwait(continueOnCapturedContext: false)));
			Beatmap beatmap2 = beatmap;
			if ((object)beatmap2 == null)
			{
				if (Hash != null)
				{
					throw new InvalidPartialHashException(Hash);
				}
				if (Key != null)
				{
					throw new InvalidPartialKeyException(Key);
				}
				throw new InvalidPartialException();
			}
			ID = beatmap2.ID;
			Name = beatmap2.Name;
			Description = beatmap2.Description;
			Uploader = beatmap2.Uploader;
			Uploaded = beatmap2.Uploaded;
			Metadata = beatmap2.Metadata;
			Stats = beatmap2.Stats;
			Versions = beatmap2.Versions;
		}

		public async Task Refresh( StandardRequestOptions options = null)
		{
			if (Client == null)
			{
				throw new NullReferenceException("Client should not be null!");
			}
			Beatmap beatmap = await Client.StatsFromHash(Hash, options ?? StandardRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
			if ((object)beatmap != null)
			{
				Name = beatmap.Name;
				Description = beatmap.Description;
				Stats = beatmap.Stats;
			}
		}

		public async Task RefreshStats( StandardRequestOptions options = null)
		{
			if (Client == null)
			{
				throw new NullReferenceException("Client should not be null!");
			}
			Beatmap beatmap = await Client.StatsFromHash(Hash, options ?? StandardRequestOptions.Default).ConfigureAwait(continueOnCapturedContext: false);
			if ((object)beatmap != null)
			{
				Stats = beatmap.Stats;
			}
		}

		public async Task<byte[]> ZipBytes(bool direct = false,  StandardRequestOptions options = null)
		{
			if (Client == null)
			{
				throw new NullReferenceException("Client should not be null!");
			}

			string str2 = (direct ? DirectDownload : DownloadURL);
			HttpRequest request = HttpRequest.FromOptions(str2, options ?? StandardRequestOptions.Default);
			return (await Client.HttpInstance.GetAsync(request).ConfigureAwait(continueOnCapturedContext: false)).Bytes;
		}

		public async Task<byte[]> CoverImageBytes( StandardRequestOptions options = null)
		{
			if (Client == null)
			{
				throw new NullReferenceException("Client should not be null!");
			}
			HttpRequest request = HttpRequest.FromOptions(CoverURL, options ?? StandardRequestOptions.Default);
			return (await Client.HttpInstance.GetAsync(request).ConfigureAwait(continueOnCapturedContext: false)).Bytes;
		}

		public bool Equals(Beatmap b)
		{
			if ((object)b == null)
			{
				return false;
			}
			if ((object)this == b)
			{
				return true;
			}
			if (GetType() != b.GetType())
			{
				return false;
			}
			if (!(ID == b.ID) && !(Key == b.Key))
			{
				return Hash == b.Hash;
			}
			return true;
		}

		public override int GetHashCode()
		{
			if (ID != null)
			{
				return ID.GetHashCode();
			}
			if (Key != null)
			{
				return Key.GetHashCode();
			}
			if (Hash != null)
			{
				return Hash.GetHashCode();
			}
			throw new NullReferenceException("ID, Key, and Hash should not all be null!");
		}

		
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Beatmap");
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
			builder.Append("Key");
			builder.Append(" = ");
			builder.Append((object)Key);
			builder.Append(", ");
			builder.Append("Name");
			builder.Append(" = ");
			builder.Append((object)Name);
			builder.Append(", ");
			builder.Append("Description");
			builder.Append(" = ");
			builder.Append((object)Description);
			builder.Append(", ");
			builder.Append("Uploader");
			builder.Append(" = ");
			builder.Append(Uploader);
			builder.Append(", ");
			builder.Append("Uploaded");
			builder.Append(" = ");
			builder.Append(Uploaded.ToString());
			builder.Append(", ");
			builder.Append("Metadata");
			builder.Append(" = ");
			builder.Append(Metadata);
			builder.Append(", ");
			builder.Append("Stats");
			builder.Append(" = ");
			builder.Append(Stats);
			builder.Append(", ");
			builder.Append("DirectDownload");
			builder.Append(" = ");
			builder.Append((object)DirectDownload);
			builder.Append(", ");
			builder.Append("DownloadURL");
			builder.Append(" = ");
			builder.Append((object)DownloadURL);
			builder.Append(", ");
			builder.Append("CoverURL");
			builder.Append(" = ");
			builder.Append((object)CoverURL);
			builder.Append(", ");
			builder.Append("Hash");
			builder.Append(" = ");
			builder.Append((object)Hash);
			builder.Append(", ");
			builder.Append("CoverFilename");
			builder.Append(" = ");
			builder.Append((object)CoverFilename);
			builder.Append(", ");
			builder.Append("Partial");
			builder.Append(" = ");
			builder.Append(Partial.ToString());
			return true;
		}

		
		public static bool operator !=(Beatmap r1, Beatmap r2)
		{
			return !(r1 == r2);
		}

		
		public static bool operator ==(Beatmap r1, Beatmap r2)
		{
			if ((object)r1 != r2)
			{
				return r1?.Equals(r2) ?? false;
			}
			return true;
		}

		
		public override bool Equals(object obj)
		{
			return Equals(obj as Beatmap);
		}

		public Beatmap _003CClone_003E_0024()
		{
			return new Beatmap(this);
		}

		private Beatmap(Beatmap original)
		{
			ID = original.ID;
			Name = original.Name;
			Description = original.Description;
			Uploader = original.Uploader;
			Uploaded = original.Uploaded;
			Metadata = original.Metadata;
			Stats = original.Stats;
			DirectDownload = original.DirectDownload;
			Versions = original.Versions;
			Client = original.Client;
		}
	}
}
