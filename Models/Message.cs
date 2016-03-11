using MongoDB.Bson;
using System;

namespace Models
{
    public class Message
    {
        public Message(){}
        
        [MongoDB.Bson.Serialization.Attributes.BsonIdAttribute]
        public string Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }     
        public long Created {get;set;}
    }
}