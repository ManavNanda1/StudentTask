using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Model.Student
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid First Name. Special characters are not allowed.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Last Name. Special characters are not allowed.")]
        public string LastName { get; set; }

        [Required]

        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(10)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string EmailId { get; set; }


        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Invalid password. Password must be at least 8 characters long, contain at least one letter, one digit, and one special character.")]
        public string Password { get; set; }

        public IFormFile ProfilePic { get; set; }

        public string ProfilePicture { get; set; }

        [Required]
        public string Skills { get; set; }

        [Required]
        public string Remarks { get; set; }

        [Required]
        public int Country { get; set; }

        public string CountryName { get; set; }
    }
}
