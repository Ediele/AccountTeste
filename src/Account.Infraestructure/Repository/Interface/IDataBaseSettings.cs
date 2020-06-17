using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Infraestructure.Repository.Interface
{
    public interface IDataBaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
