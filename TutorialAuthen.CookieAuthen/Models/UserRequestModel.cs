namespace TutorialAuthen.CookieAuthen.Models
{
    public class UserRequestModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "Guest";
    }
}
