using Account.Infraestructure.Repository.Interface;

namespace Account.Infraestructure.Data
{
    public class DbUsersConectionSettings : IMongoConfigurationSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
