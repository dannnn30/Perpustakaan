using System;
using System.Collections.Generic;
using System.Text;

namespace Perpustakaan
{
    public class User
    {
        public int UserId { get; set; }      // auto increment
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
    }
}
