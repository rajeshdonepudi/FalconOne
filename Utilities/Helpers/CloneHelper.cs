namespace FalconOne.Helpers.Helpers
{
    public static class CloneHelper
    {
        public static string GetCloneEmail(string email)
        {
            int atIndex = email.IndexOf('@');

            if (atIndex == -1)
                throw new ApiException("Invalid email format");

            string modifiedEmail = email.Insert(atIndex, "-cloned");
            return modifiedEmail;
        }
    }
}
