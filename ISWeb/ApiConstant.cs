namespace ISWeb
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

        //API Province
        private const string ProvincePreFix = "api/Province/";
        public const string GetAllProvince = ProvincePreFix + "get-all";
        public const string CreateProvince = ProvincePreFix + "create";
        public const string GetProvinceId = ProvincePreFix + "get-by-id";
        public const string DeleteProvince = ProvincePreFix + "delete";

        //API Mentor
        private const string MentorPreFix = "api/Mentor/";
        public const string GetAllMentor = MentorPreFix + "get-all";
        public const string CreateMentor = MentorPreFix + "create";
        public const string GetMentorId = MentorPreFix + "get-by-id";
        public const string DeleteMentor = MentorPreFix + "delete";


        //API Genre
        private const string GenrePreFix = "api/Genre/";
        public const string GetAllGenre = GenrePreFix + "get-all";
        public const string CreateGenre = GenrePreFix + "create";
        public const string GetGenreId = GenrePreFix + "get-by-id";
        public const string DeleteGenre = GenrePreFix + "delete";

        //API Category
        private const string CategoryPreFix = "api/Category/";
        public const string GetAllCategory = CategoryPreFix + "get-all";
    }

}
