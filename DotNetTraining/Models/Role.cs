using System.ComponentModel.DataAnnotations;

namespace DotNetTraining.Models
{
    public class Role
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Role() { }
        public Role(string name, string description)
        {
            Name = name;
            Description = description;

        }

    }
}
