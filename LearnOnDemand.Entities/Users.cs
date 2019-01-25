using System;
using System.Collections.Generic;

namespace LearnOnDemand.Entities
{
    public partial class Users
    {
        public int Id { get; set; }
        public int OrganizationKey { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Organizations OrganizationKeyNavigation { get; set; }
    }
}
