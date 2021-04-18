﻿namespace ISWeb
{
    public static class ApiConstant
    {
        #region Manager
        //API Login
        private const string AuthenticationPrefix = "api/Authentication/";

        public const string Login = AuthenticationPrefix + "Login";
        public const string RefreshToken = AuthenticationPrefix + "RefreshToken";
        public const string CheckValidUser = AuthenticationPrefix + "CheckValidUser";
        public const string ChangePassword = AuthenticationPrefix + "ChangePassword";

        //API WebLink
        private const string WebLinkPrefix = "api/WebLink/";
        public const string GetAllWebLink = WebLinkPrefix + "get-all";
        public const string CreateWebLink = WebLinkPrefix + "create-weblink";
        public const string GetWebLinkId = WebLinkPrefix + "get-by-id";
        public const string DeleteWebLink = WebLinkPrefix + "delete-weblink";
        #endregion


    }

}