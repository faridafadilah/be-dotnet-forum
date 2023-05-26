using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceWalk.Models
{
  public class MainForum : BaseModel
  {
    [Required]
    public string title { get; set; }
    public string name_image { get; set; }
    public string url_image { get; set; }
    public string description { get; set; }
    [NotMapped]
    public IEnumerable<SubForum> subForums {get; set;}
  }
}