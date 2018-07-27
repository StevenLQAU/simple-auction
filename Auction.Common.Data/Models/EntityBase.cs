using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Common.Data.Models
{
    public abstract class EntityBase
    {
        [BsonId]
        public virtual ObjectId Id { get; set; }
    }
}
