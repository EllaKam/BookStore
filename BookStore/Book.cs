using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BookStore
{
    public enum Genre
    {
        Fantasy,
        Computer,
        Romance,
        Horror,
        [EnumMember(Value = "Science Fiction")]
        ScienceFiction
    }

    public class Book
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("genre")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Genre Genre { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("publish_date")]
        public DateTime PublishDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [VisibleAttribute(NotVisible = true)]
        public bool IsDelete { get; set; } = false;
    }
}
