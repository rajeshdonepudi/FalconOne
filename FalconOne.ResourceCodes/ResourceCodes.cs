namespace FalconOne.ResourceCodes
{
    public class ResourceIdentifier
    {
        public static class Settings
        {
            public const string HASH_PASSWORD = "HASH_PASSWORD";
        }

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

        public static class User
        {
            public const string ADD_NEW_USER = "ADD_NEW_USER";
            public const string DELETE_USER = "DELETE_USER";
            public const string USER_MANAGMENT_DASHBOARD = "USER_MANAGEMENT_DASHBOARD";
        }

        public static class Security
        {
            public const string GET_SECURITY_CLAIMS_LOOKUP = "GET_SECURITY_CLAIMS_LOOKUP";
            public const string GET_SECURITY_ROLES_LOOKUP = "GET_SECURITY_ROLES_LOOKUP";
            public const string HASH_USER_PASSWORD = "HASH_USER_PASSWORD";
            public const string CREATE_NEW_POLICY = "CREATE_NEW_POLICY";
            public const string GET_ROLE = "GET_ROLE";
            public const string CREATE_ROLE = "CREATE_ROLE";
            public const string DELETE_ROLE = "DELETE_ROLE";
            public const string GET_ALL_ROLES = "GET_ALL_ROLES";
        }

        public static class Logging
        {
            public const string VIEW_SECURITY_LOGS = "VIEW_SECURITY_LOGS";
        }
    }
}
