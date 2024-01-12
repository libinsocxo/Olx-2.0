using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olx2._0.Models
{
    public class AuthModel
    {

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Username")] 
        public  string UserName { get; set;}

        [BsonElement("Password")]
        public string Password { get; set;}

    }
}