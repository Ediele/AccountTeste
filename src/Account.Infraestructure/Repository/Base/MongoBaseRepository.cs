using Account.Application.Core.Entity.Interface.Base;
using Account.Infraestructure.Repository.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Infraestructure.Repository.Base
{
    public class MongoBaseRepository<T> where T : EntityBase
    {
        private readonly IMongoCollection<T> _collectionItem;

        public MongoBaseRepository(IMongoConfigurationSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collectionItem = database.GetCollection<T>(settings.CollectionName);
        }

        public IList<T> Get()
        {
            return _collectionItem.Find(entity => true).ToList();
        }

        public T Get(string id)
        {
            return _collectionItem.Find<T>(entity => entity.Id == id).FirstOrDefault();
        }


        public void Create(T entity)
        {
            _collectionItem.InsertOne(entity);
        }

        public void Update(string id, T entity)
        {
            _collectionItem.ReplaceOne(u => u.Id == id, entity);
        }


        public void Remove(string id)
        {
            _collectionItem.DeleteOne(entity => entity.Id == id);
        }

    }
}
