namespace Electronic_Store_Api.Entities
{
    public class User
    {
        public long? EsUserId { get; set; }
        public string EsUserName { get; set; }
        public string EsUserFirstName { get; set; }
        public string EsUserLastName { get; set; }
        public string EsUserMailId { get; set; }
        public long? EsUserMobNum { get; set; }
        public long? EsUserZip { get; set; }
        public string EsUserCountry { get; set; }
        public string EsUserState { get; set; }
        public string EsUserGender { get; set; }
        public Boolean IsAdmin { get; set; }
        public string EsUserDob { get; set; }
    }
}
