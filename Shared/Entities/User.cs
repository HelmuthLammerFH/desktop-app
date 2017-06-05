using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }
        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }
        [DataMember(Name = "birthdate")]
        public DateTime Birthdate { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "passwort")]
        public string Passwort { get; set; }
        [DataMember(Name = "createdFrom")]
        public string CreatedFrom { get; set; }
        [DataMember(Name = "changedFrom")]
        public string ChangedFrom { get; set; }
        [DataMember(Name = "syncedFrom")]
        public int SyncedFrom { get; set; }
        [DataMember(Name = "deleteFlag")]
        public int DeleteFlag { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
