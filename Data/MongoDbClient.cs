using MongoDB.Driver;

namespace blazor_experiment.Data
{
    public class MongoDbClient
    {
        private readonly IMongoDatabase _mongoDatabase;
        public MongoDbClient()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _mongoDatabase = client.GetDatabase("test");
        }
        public IMongoCollection<Student> StudentRecord
        {
            get
            {
                //Student is the model object for the record, and Students is the name of the mongo collection
                return _mongoDatabase.GetCollection<Student>("Students");
            }
        }
    }
}
