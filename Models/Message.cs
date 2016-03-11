using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class Message
    {        
        [BsonIdAttribute]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }     
        public long Created {get;set;}
    }
}