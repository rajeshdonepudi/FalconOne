namespace FalconOne.ResourceCodes
{
    public class AppResourceCodes
    {
        public static class Account
        {
            public const string USER_CREATE = "USER_CREATE";
            public const string LOGIN = "LOGIN";
            public const string GET_USER = "GET_USER";
            public const string NEW_USER_SIGNUP = "REGISTER_NEW_USER";
            public const string FORGOT_PASSWORD = "FORGOT_PASSWORD";
            public const string RESET_PASSWORD = "RESET_PASSWORD";
            public const string REVOKE_REFRESH_TOKEN = "REVOKE_REFRESH_TOKEN";
            public const string REFRESH_TOKEN = "REFRESH_TOKEN";
            public const string AAC_UPDATE_EMAIL_CONFIRMED = "AAC_UPDATE_EMAIL_CONFIRMED";
        }
        public static class Settings
        {
            public const string GET_SETTING_BY_TYPE = "GET_SETTING_BY_TYPE";
            public const string GET_SETTING_TYPES = "GET_SETTING_TYPES";
            public const string UPDATE_SETTINGS = "UPDATE_SETTINGS";
            public const string GET_TENANT_SETTINGS = "GET_TENANT_SETTINGS";
            public const string ADD_NEW_SETTING = "ADD_NEW_SETTING";
            public const string DELETE_SETTING = "DELETE_SETTING";
        }

        public static class Security
        {
            public const string GET_SECURITY_CLAIMS_LOOKUP = "GET_SECURITY_CLAIMS_LOOKUP";
            public const string GET_SECURITY_ROLES_LOOKUP = "GET_SECURITY_ROLES_LOOKUP";
        }

        public static class Fonts
        {
            public const string GET_FONT_FAMILIES = "GET_FONT_FAMILIES";
        }
    }
}
