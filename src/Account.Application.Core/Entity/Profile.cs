using Account.Application.Core.Entity.Enum;
using Account.Application.Core.Entity.Interface.Base;
using System;

namespace Account.Application.Core.Entity
{
    public class Profile : EntityBase
    {
        public string Id
        {
            get { return Id ?? new Guid().ToString(); }
            set { Id = value; }
        }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public ProfileType ProfileType { get; set; }

        public Address Address { get; set; }

    }
}
