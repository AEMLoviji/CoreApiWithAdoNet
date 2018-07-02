using System.Runtime.Serialization;

namespace CoreApiWithAdoNet.Model
{
    [DataContract]
    public class Team
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Country")]
        public string Country { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Phone")]
        public string Phone { get; set; }

        [DataMember(Name = "WillPlayInChanpionsLeague")]
        public bool WillPlayInChanpionsLeague { get; set; }
    }
}
