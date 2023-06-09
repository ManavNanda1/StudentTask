using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Model.User
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(8)]
        [MaxLength(90)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; }

        public string UserEmail { get; set; }
        public string UserId { get; set; }
    }
}
