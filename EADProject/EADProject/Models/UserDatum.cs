using System;
using System.Collections.Generic;

#nullable disable

namespace EADProject.Models
{
    public partial class UserDatum
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
