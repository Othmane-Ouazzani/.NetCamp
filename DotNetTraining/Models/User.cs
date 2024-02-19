using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DotNetTraining.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength (50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Role> roles { get; set; }

        public User(string id, string firstName, string lastName, string password, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            this.roles =new List<Role>();
        }
    }
}
