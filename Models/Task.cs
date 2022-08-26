using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace minimalapientityFramework.Models;

public class Taskk
{
    [Key]
    public Guid TaskkId { get; set; }

    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    public string Description { get; set; }

    public Priority TaskPriority { get; set; }

    public DateTime CreatedDate { get; set; }

    //virtual property is for get all information about the category
    public virtual Category Category { get; set; }

    //NotMapped if for not to show in the database
    [NotMapped]
    public string Resume { get; set; }

}

public enum Priority
{
    low,
    medium,
    high
}