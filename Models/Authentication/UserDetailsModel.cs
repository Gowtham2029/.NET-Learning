namespace Practice_A.Models.Authentication
{
    public class UserDetailsModel
    {
        public int user_id {  get; set; }

        public string name { get; set; } = string.Empty;

        public string? Email { get; set; }
    }
}
