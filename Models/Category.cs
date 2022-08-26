using System.ComponentModel.DataAnnotations;

namespace minimalapientityFramework.Models;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; }

    public string Description { get; set; }

    //all task associated with the category
    public virtual ICollection<Taskk> Tasks { get; set; }
}