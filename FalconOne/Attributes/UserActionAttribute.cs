namespace FalconOne.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class UserActionAttribute : Attribute
    {
        public string ResourceCode { get; }
        public UserActionAttribute(string resourceCode)
        {
            ResourceCode = resourceCode;
        }
    }
}
