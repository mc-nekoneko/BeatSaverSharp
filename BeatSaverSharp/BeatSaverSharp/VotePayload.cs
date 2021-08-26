using System;
using System.IO;
using System.Runtime.CompilerServices;
using BeatSaverSharp.Net;
using Newtonsoft.Json;

namespace BeatSaverSharp
{
	
	
	internal struct VotePayload
	{
		
		internal enum VoteDirection : sbyte
		{
			Up = 1,
			Down = -1
		}

		[JsonProperty("steamID")]
		public string SteamID
		{
			
			get;
		}

		[JsonIgnore]
		public byte[] Ticket
		{
			
			get;
		}

		[JsonProperty("ticket")]
		public string TicketString => string.Concat(Array.ConvertAll(Ticket, (byte x) => x.ToString("X2")));

		[JsonIgnore]
		public VoteDirection Direction
		{
			
			get;
		}

		[JsonProperty("direction")]
		public sbyte DirectionByte => (sbyte)Direction;

		public VotePayload(string steamID, byte[] ticket, VoteDirection direction)
		{
			SteamID = steamID;
			Ticket = ticket;
			Direction = direction;
		}

		public string ToJson()
		{
			using (StringWriter stringWriter = new StringWriter())
			{
				using (JsonTextWriter jsonWriter = new JsonTextWriter(stringWriter))
				{
					Http.Serializer.Serialize(jsonWriter, this);
					return stringWriter.ToString();
				}
			}
		}
	}
}
