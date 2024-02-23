using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTraining.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
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

        public ICollection<UserRole> roles { get; set; }

        public User(Guid Id, string firstName, string lastName, string password, string email)
        {
            this.Id = Id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            this.roles = new List<UserRole>();
        }

      
    }
}
