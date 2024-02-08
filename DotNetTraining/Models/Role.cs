using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTraining.Models
{
    class Role
    {
        private string Name { get; set; }
        private string Description { get; set; }
        public Role() { }
        public Role(string name, string description)
        {
            Name = name;
            Description = description;

        }

    }
}
