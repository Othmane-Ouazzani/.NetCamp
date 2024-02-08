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
        
        private string Id { get; set; }
        
        private string FirstName { get; set; }
        
        private string LasttName { get; set; }
        
        private string Password { get; set; }
        
        private string Email { get; set; }

        private Role role { get; set; }

       
       
    }
}
