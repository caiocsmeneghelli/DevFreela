using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class CreateUserViewModel
    {
        public string FullName { get; private set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}