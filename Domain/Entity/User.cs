namespace Domain.Entity
{
    public class User : EntityBase
    {
        public User(string username, string password, string role) 
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public User() { }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}