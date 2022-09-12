using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthdate, bool active)
        {
            FullName = fullName;
            Email = email;
            Birthdate = birthdate;
            Active = active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime Birthdate { get; private set; }
        public bool Active { get; private set; }
    }
}