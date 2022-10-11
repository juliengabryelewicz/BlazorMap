namespace BlazorMap.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }

        public string Role { get; set; } = "Admin";

    }
}
