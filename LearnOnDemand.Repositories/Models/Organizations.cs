using System;
using System.Collections.Generic;

namespace LearnOnDemand.Repositories.Models
{
    public partial class Organizations
    {
        public Organizations()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Map { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
