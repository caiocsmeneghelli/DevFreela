namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthdate, bool active, string role = null)
        {
            FullName = fullName;
            Email = email;
            Birthdate = birthdate;
            Active = active;
            Role = role;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthdate { get; private set; }
        public bool Active { get; private set; }
        public string Role { get; private set; }
    }
}