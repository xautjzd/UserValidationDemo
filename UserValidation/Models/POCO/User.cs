using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UserValidation.Models.POCO
{
    public class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        public int UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Enabled { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}