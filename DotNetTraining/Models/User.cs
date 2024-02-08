using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTraining.Models
{
    class User
    {
        [Required]
        private string Id { get; set; }
        [Required]
        private string FirstName { get; set; }
        [Required]
        private string LasttName { get; set; }
        [Required]
        private string Password { get; set; }
        [Required]
        private string Email { get; set; }

        private Role role { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
       
    }
}
