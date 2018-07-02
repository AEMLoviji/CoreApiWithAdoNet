using System.ComponentModel;

namespace CoreApiWithAdoNet.Enums
{
    public enum ResultCode
    {
        [Description("Ok")]
        Ok = 1,
        [Description("Data Already Exists")]
        AlreadyExists = 2,
        [Description("NotFound")]
        NotFound = 3
    }
}
