namespace FalconeOne.BLL.Helpers
{
    public static class ErrorMessages
    {
        public static string LOGIN_FAILED = "Login failed.";
        public static string SOMETHING_WENT_WRONG = "Something went wrong! Please contact administrator.";
        public static string USER_CREATED_SUCCESSFULLY = "Successfully created the user.";
        public static string USER_NOT_FOUND = "User not found.";
        public static string USER_CREATION_FAILED = "User creation failed.";
        public static string FAILED_TO_CREATE_USER = "Failed to create the user.";
        public static string FORGOT_PASSWORD_SUCCESS = "Password reset instructions sent to your registered email.";
        public static string RESET_PASSWORD_SUCESS = "Password reset successfull.";
        public static string RESET_PASSWORD_FAILED = "Failed to reset the password.";
        public static string EMAIL_CONFIRM_SUCCESS = "Email confirmed successfully.";
        public static string INVALID_USER_ID = "Invalid user id.";
        public static string USER_DELETION_FAILED = "Failed to delete the user.";
        public static string USER_DELETED_SUCCESSFULLY = "User deleted successfully.";
        public static string FAILED_TO_CONFIRM_EMAIL = "Failed to confirm email.";
        public static string PLEASE_CONFIRM_EMAIL = "Email not yet confirmed, please confirm the email.";
        public static string NO_USERS_FOUND = "No users found.";
        public static string REFRESH_TOKEN_EXPIRED = "Refresh token expired.";
        public static string REFRESH_TOKEN_NOT_FOUND = "Refresh token not found.";
        public static string REFRESH_TOKEN_REVOKED = "Refresh token revoked.";
        public static string INVALID_REFRESH_TOKEN = "Invalid refresh token.";
        public static string REUSE_OF_REVOKED_ANCESTOR_TOKEN = "Attempted reuse of revoked ancestor token.";
        public static string REPLACED_WITH_NEW_TOKEN = "Replaced by new token.";
        public static string INVALID_REQUEST = "Invalid request.";
        public static string FAILED_TO_UPDATE_USER = "Failed to update user.";
        public static string ROLE_NOT_FOUND = "Role not found.";
        public static string EMAIL_CONFIRM_FAILED = "Email confirmation failed.";
    }

    public static class MessageHelper
    {
        public static class SuccessMessages
        {
            public static string SUCESSFULL = "Successfull.";
            public static string LOGIN_SUCCESSFULL = "Login successfull.";
        }
        public static class LoginErrors
        {
            public static string LOGIN_FAILED = "Login attempt failed.";
            public static string LOGIN_SUCCESSFUL = "Login successful.";
            public static string ACCOUNT_LOCKED = "You account has been locked out. Please try after minutes.";
        }

        public static class GeneralErrors
        {
            public static string SOMETHING_WENT_WRONG = "Something went wrong! Please contact the administrator.";
            public static string INVALID_REQUEST = "Invalid request.";
        }

        public static class UserCreationErrors
        {
            public static string USER_CREATED_SUCCESSFULLY = "User created successfully.";
            public static string USER_CREATION_FAILED = "Failed to create the user.";
            public static string FAILED_TO_CREATE_USER = "Failed to create the user.";
        }

        public static class UserNotFoundErrors
        {
            public static string USER_NOT_FOUND = "User not found.";
            public static string NO_USERS_FOUND = "No users found.";
        }

        public static class PasswordResetErrors
        {
            public static string FORGOT_PASSWORD_SUCCESS = "Password reset instructions sent to your registered email.";
            public static string RESET_PASSWORD_SUCCESS = "Password reset successful.";
            public static string RESET_PASSWORD_FAILED = "Failed to reset the password.";
        }

        public static class EmailConfirmationErrors
        {
            public static string EMAIL_CONFIRM_SUCCESS = "Email confirmed successfully.";
            public static string EMAIL_CONFIRM_FAILED = "Email confirmation failed.";
            public static string PLEASE_CONFIRM_EMAIL = "Email not yet confirmed. Please confirm the email.";
            public static string FAILED_TO_CONFIRM_EMAIL = "Failed to confirm email.";
        }

        public static class UserDeletionErrors
        {
            public static string USER_DELETION_FAILED = "Failed to delete the user.";
            public static string USER_DELETED_SUCCESSFULLY = "User deleted successfully.";
        }

        public static class TokenErrors
        {
            public static string REFRESH_TOKEN_EXPIRED = "Refresh token expired.";
            public static string REFRESH_TOKEN_NOT_FOUND = "Refresh token not found.";
            public static string REFRESH_TOKEN_REVOKED = "Refresh token revoked.";
            public static string INVALID_REFRESH_TOKEN = "Invalid refresh token.";
            public static string REUSE_OF_REVOKED_ANCESTOR_TOKEN = "Attempted reuse of revoked ancestor token.";
            public static string REPLACED_WITH_NEW_TOKEN = "Replaced by a new token.";
        }

        public static class UpdateUserErrors
        {
            public static string FAILED_TO_UPDATE_USER = "Failed to update user.";
        }

        public static class RoleErrors
        {
            public static string ROLE_NOT_FOUND = "Role not found.";
        }
    }
}
