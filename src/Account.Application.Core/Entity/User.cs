using Account.Application.Core.Entity.Interface.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;


namespace Account.Application.Core.Entity
{
    public class User : EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Profile> Profiles { get; set; }
    }    
}
