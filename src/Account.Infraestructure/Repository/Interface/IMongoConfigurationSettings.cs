using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Infraestructure.Repository.Interface
{
    public interface IMongoConfigurationSettings : IDataBaseSettings
    {
        string CollectionName { get; set; }
    }
}
