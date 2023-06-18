namespace FalconOne.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ResourceIdentifierAttribute : Attribute
    {
        public string ResourceCode { get; }
        public ResourceIdentifierAttribute(string resourceCode)
        {
            ResourceCode = resourceCode;
        }
    }
}
