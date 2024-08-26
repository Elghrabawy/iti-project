namespace Online_Store.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Address
        {
            get
            {
                return State + ", " + City;
            }
        }
        public string? Zip { get; set; }
    }
}
