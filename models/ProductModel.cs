using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olx2._0.Models
{
    public class ProductModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("productName")]
        public string productName { get; set; }

        [BsonElement("productDescription")]
        public string productDescription { get; set; }

        [BsonElement("imagefile")]
        public string ImageFile { get; set; }

        [BsonElement("contactNumber")]
        public string contactNumber { get; set; }

        [BsonElement("userEmail")]
        public string userEmail { get; set; }
    }
}