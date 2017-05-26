using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{
    public class DummyUser
    {

        public int ID { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }
    }
}
