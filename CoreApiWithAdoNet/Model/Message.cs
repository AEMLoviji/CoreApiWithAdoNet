using CoreApiWithAdoNet.Enums;
using System.Runtime.Serialization;

namespace CoreApiWithAdoNet.Model
{
    [DataContract]
    public class Message<T>
    {
        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "InfoMessage")]
        public ResultCode InfoMessage { get; set; }

        [DataMember(Name = "Data")]
        public T Data { get; set; }
    }
}
