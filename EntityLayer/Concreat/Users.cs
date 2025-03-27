using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
    public class Users
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string? Language { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<News> news { get; set; }
    }
}
