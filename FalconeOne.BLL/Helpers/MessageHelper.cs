﻿namespace FalconeOne.BLL.Helpers
{
    public static class MessageHelper
    {
        public static string LOGIN_FAILED = "Login failed.";
        public static string SOMETHING_WENT_WRONG = "Something went wrong! Please contact administrator.";
        public static string USER_CREATED_SUCCESSFULLY = "Successfully created the user.";
        public static string USER_NOT_FOUND = "User not found.";
        public static string LOGIN_SUCCESSFULL = "Login successfull.";
        public static string FAILED_TO_CREATE_USER = "Failed to create the user.";
        public static string FORGOT_PASSWORD_SUCCESS;
        public static string RESET_PASSWORD_SUCESS;
        public static string RESET_PASSWORD_FAILED;
        public static string EMAIL_CONFIRM_SUCCESS;
        public static string EMAIL_CONFIRM_FAILED;
        public static string INVALID_USER_ID;
        public static string USER_DELETION_FAILED;
        public static string USER_DELETED_SUCCESSFULLY;
        public static string SUCESSFULL;
        public static string FAILED_TO_CONFIRM_EMAIL;
        public static string PLEASE_CONFIRM_EMAIL;
        public static string NO_USERS_FOUND;
        public static string REFRESH_TOKEN_EXPIRED;
        public static string REFRESH_TOKEN_NOT_FOUND;
        public static string REFRESH_TOKEN_REVOKED;
        public static string INVALID_REFRESH_TOKEN;
        public static string REUSE_OF_REVOKED_ANCESTOR_TOKEN;
        public static string REPLACED_WITH_NEW_TOKEN = "Replaced by new token.";
        public static string INVALID_REQUEST = "Invalid request.";

        public static string ROLE_NOT_FOUND { get; internal set; }
    }
}
