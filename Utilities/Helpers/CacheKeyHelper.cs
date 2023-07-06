namespace FalconOne.Helpers.Helpers
{
    public static class CacheKeyHelper
    {
        public static class SiteSettings
        {
            public static string TENANT_SITE_SETTINGS = "{0}_SITE_SETTINGS";
            public static string TENANT_SITE_SETTINGS_BY_TYPE = "{0}_SITE_SETTINGS_BY_{1}";
            public static string TENANT_SITE_SETTINGS_BY_NAME = "{0}_SITE_SETTINGS_BY_{1}";
        }
    }
}
